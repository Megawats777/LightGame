using UnityEngine;
using System.Collections;

public class CameraOffsetZone : MonoBehaviour
{
    /*--New Camera Offset Properties--*/
    [Header("New Camera Offset Properties")]
    public float newCameraOffsetX = 0.0f;
    public float newCameraOffsetY = 0.0f;

    // Toogles if the camera offset only occurs in this zone
    [Tooltip("Toogles if the camera offset only occurs in this zone")]
    public bool offsetOnlyInZone = false;

    // Reference to the game camera
    private CameraController gameCamera;

    // Called before start
    public void Awake()
    {
        // Get the game camera
        gameCamera = FindObjectOfType<CameraController>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // When an object overlaps with this zone
    public void OnTriggerEnter(Collider other)
    {
        // If the overlapping object was the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Set the offset of the game camera
            gameCamera.setCameraTrackingOffset(newCameraOffsetX, newCameraOffsetY);
        }
    }

    // When an object is done overlaping this zone
    public void OnTriggerExit(Collider other)
    {
        // If the camera offset exists only in this zone
        if (offsetOnlyInZone)
        {
            // If the object was the player
            if (other.gameObject.CompareTag("Player"))
            {
                // Set the offset of the camera to be zero
                gameCamera.setCameraTrackingOffset(0.0f, 0.0f);
            }
        }
    }

    /*--Editor Functions--*/

    // Draw a gizmo
    public void OnDrawGizmos()
    {
        // Set the colour of the gizmo
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.5f);

        // Draw a cube
        Gizmos.DrawCube(transform.position, transform.lossyScale);
    }
}
