using UnityEngine;
using System.Collections;

public class CameraOffsetZone : MonoBehaviour
{
    /*--New Camera Offset Properties--*/
    [Header("New Camera Offset Properties")]
    public float newCameraOffsetX = 0.0f;
    public float newCameraOffsetY = 0.0f;

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
