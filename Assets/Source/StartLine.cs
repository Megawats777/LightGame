using UnityEngine;
using System.Collections;

public class StartLine : MonoBehaviour
{
    /*--External References--*/
    private TimeTrialGameManager timeTrialGameManager;
    private CameraController cameraController;

    // Called before start
    public void Awake()
    {
        // Get the timeTrialGameManager
        timeTrialGameManager = FindObjectOfType<TimeTrialGameManager>();

        // Get the camera controller
        cameraController = FindObjectOfType<CameraController>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // When an object overlaps the trigger
    public void OnTriggerEnter(Collider other)
    {
        // If the overlaping object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Start the game clock
            timeTrialGameManager.startGameClock();

            // Set the game camera to follow the player
            cameraController.isTrackingPlayer = true;
        }
    }

    // Draw editor gizmos
    public void OnDrawGizmos()
    {
        /*--Draw a text label over the object--*/

        // The position of the text label
        Vector3 textLabelPos = transform.position + new Vector3(0.0f, 1.0f, 0.0f);

        // Set the colour of the text label
        UnityEditor.Handles.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        
        // Set the text of the text label
        UnityEditor.Handles.Label(textLabelPos, "Start Line");
    }
}
