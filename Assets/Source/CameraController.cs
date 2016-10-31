using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class CameraController : MonoBehaviour
{
    // Is the camera tracking the player
    public bool isTrackingPlayer = true;

    // Is the camera shaking
    public bool isCameraShaking = false;

    // Camera blend time
    public float cameraBlendSpeed = 5.0f;

    /*--Camera Shake Properties--*/
    [Header("Camera Shake Properties")]

    // Intensity of the camera shake
    public float cameraShakeIntensity = 1.0f;

    // The length of the camera shake
    public float cameraShakeLength = 0.5f;

    // The position of the camera before the camera
    private Vector3 preCameraShakePosition;

    // Reference to the player's rigidbody component
    private Rigidbody playerRigidBody;

    // GameObject reference to the player
    private GameObject playerSphere;

    // Reference to the player controller class
    private PlayerController playerController;

    // Reference to depth of field component
    private DepthOfField dofComponent;

    // Called before start
    public void Awake()
    {
        // Get the depth of field component
        dofComponent = GetComponent<DepthOfField>();

        // Get a reference to the player
        playerSphere = GameObject.FindGameObjectWithTag("Player");
    }

    // Use this for initialization
    void Start()
    {
        // Get the player controller class from the player sphere
        playerController = playerSphere.GetComponent<PlayerController>();

        // Get the rigidbody component from the player sphere
        playerRigidBody = playerSphere.GetComponent<Rigidbody>();

        // Set the focus transform for the dof component
        dofComponent.focalTransform = playerSphere.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Control camera shake
        controlCameraShake();
    }

    // Called before physics calculations
    public void FixedUpdate()
    {
        // Set the position of the camera
        setCameraPosition();
    }

    // Called after update
    public void LateUpdate()
    {
       
    }

    // Set the position of the camera
    private void setCameraPosition()
    {
        /*
        // Set the camera offset values   
        cameraOffsetX = Mathf.Lerp(cameraOffsetX, cameraPositionOffset * playerController.axisHorizontal, Time.deltaTime * cameraOffsetBlendSpeed);
        cameraOffsetY = Mathf.Lerp(cameraOffsetY, cameraPositionOffset * playerController.axisVertical, Time.deltaTime * cameraOffsetBlendSpeed);
        */

        // The new camera positions by axis
        float cameraPosX = playerRigidBody.position.x;
        float cameraPosY = playerRigidBody.position.y;

        // If the camera is tracking the player
        if (isTrackingPlayer)
        {
            // The new camera position
            Vector3 newCameraPosition = new Vector3(cameraPosX, cameraPosY, transform.position.z);

            // Interpolate to the new camera position
            transform.position = Vector3.Lerp(transform.position, newCameraPosition, Time.deltaTime * cameraBlendSpeed);
        }
    }

    // Control camera shake
    private void controlCameraShake()
    {
        if (isCameraShaking)
        {
            // Camera shake positions
            float cameraShakePosX = preCameraShakePosition.x;
            float cameraShakePosY = Mathf.Sin(Time.timeSinceLevelLoad * cameraShakeIntensity) + preCameraShakePosition.y;
            Vector3 cameraShakePosition = new Vector3(cameraShakePosX, cameraShakePosY, transform.position.z);

            // Set the position of the camera
            transform.position = cameraShakePosition;
        }
    }

    // Shake camera
    public IEnumerator shakeCamera()
    {
        // Set the pre camera shake position
        preCameraShakePosition = transform.position;

        // Stop the tracking the player
        isTrackingPlayer = false;

        // Set the camera to be shaking
        isCameraShaking = true;

        // Have a delay
        yield return new WaitForSeconds(cameraShakeLength);

        // Set the camera to not be shaking
        isCameraShaking = false;

        // Resume tracking the player
        isTrackingPlayer = true;
    }
}
