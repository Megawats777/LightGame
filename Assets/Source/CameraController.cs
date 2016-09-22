using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    // Camera blend time
    public float cameraBlendSpeed = 5.0f;

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

    // Set the position of the camera
    private void setCameraPosition()
    {

        // The new camera position
        Vector3 newCameraPosition = new Vector3(playerSphere.transform.position.x, playerSphere.transform.position.y, transform.position.z);

        // Interpolate to the new camera position
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, Time.deltaTime * cameraBlendSpeed);
    }
}
