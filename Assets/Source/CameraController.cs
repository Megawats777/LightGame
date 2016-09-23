using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    // Camera blend time
    public float cameraBlendSpeed = 5.0f;

    // Reference to the player's rigidbody component
    private Rigidbody playerRigidBody;

    // GameObject reference to the player
    private GameObject playerSphere;

    // Called before start
    public void Awake()
    {
        // Get a reference to the player
        playerSphere = GameObject.FindGameObjectWithTag("Player");
    }

    // Use this for initialization
    void Start()
    {
        // Get the rigidbody component from the player sphere
        playerRigidBody = playerSphere.GetComponent<Rigidbody>();
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
        // The new camera position
        Vector3 newCameraPosition = new Vector3(playerRigidBody.position.x, playerRigidBody.position.y, transform.position.z);

        // Interpolate to the new camera position
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, Time.deltaTime * cameraBlendSpeed);
    }
}
