using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class CameraController : MonoBehaviour
{
    // Is the camera tracking the player
    public bool isTrackingPlayer = true;

    // Camera blend time
    public float cameraBlendSpeed = 5.0f;

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
}
