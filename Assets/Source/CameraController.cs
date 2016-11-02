using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class CameraController : MonoBehaviour
{
    /*--Camera Tracking Properties--*/
    [Header("Camera Tracking Properties")]

    // Is the camera tracking the player
    public bool isTrackingPlayer = true;

    // Is the camera tracking the player by a certain axis
    public bool isCameraTrackingXAxis = true;
    public bool isCameraTrackingYAxis = true;

    // Camera tracking offset
    public Vector3 cameraTrackingOffset = new Vector3(0.0f, 0.0f, 0.0f);

    // Camera tracking speed time
    public float cameraTrackingSpeed = 5.0f;

    /*--Camera Shake Properties--*/
    [Header("Camera Shake Properties")]

    // Is the camera shaking
    public bool isCameraShaking = false;

    // Intensity of the camera shake per axis
    public float cameraShakeIntensityYAxis = 1.0f;
    public float cameraShakeIntensityXAxis = 1.0f;

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
        // The new camera positions by axis
        float cameraPosX = playerRigidBody.position.x;
        float cameraPosY = playerRigidBody.position.y;

        // The new camera position
        Vector3 newCameraPosition;

        // If the camera is tracking the player
        if (isTrackingPlayer)
        {
            // If the camera is tracking the X axis of the player
            if (isCameraTrackingXAxis && !isCameraTrackingXAxis)
            {
                // Only track the X axis of the player
                newCameraPosition = new Vector3(cameraPosX, transform.position.y, transform.position.z);
            }

            // If the camera is tracking the Y axis of the player
            else if (isCameraTrackingYAxis && !isCameraTrackingXAxis)
            {
                // Only track the Y axis of the player
                newCameraPosition = new Vector3(transform.position.x, cameraPosY, transform.position.z);
            }

            // If the camera is tracking the X and Y axis of the player
            else if (isCameraTrackingXAxis && isCameraTrackingYAxis)
            {
                // Track both the X and Y axis of the player
                newCameraPosition = new Vector3(cameraPosX, cameraPosY, transform.position.z);
            }

            // Other wise do not track a position
            else
            {
                newCameraPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }

            // Add an offset to the new camera position
            newCameraPosition += new Vector3(cameraTrackingOffset.x, cameraTrackingOffset.y, cameraTrackingOffset.z);

            // Interpolate to the new camera position
            transform.position = Vector3.Lerp(transform.position, newCameraPosition, Time.deltaTime * cameraTrackingSpeed);
        }
    }

    // Control camera shake
    private void controlCameraShake()
    {
        if (isCameraShaking)
        {
            // Camera shake positions
            float cameraShakePosX = Mathf.Cos(Time.timeSinceLevelLoad * cameraShakeIntensityXAxis) + preCameraShakePosition.x;
            float cameraShakePosY = Mathf.Sin(Time.timeSinceLevelLoad * cameraShakeIntensityYAxis) + preCameraShakePosition.y;
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
