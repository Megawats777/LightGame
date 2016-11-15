using UnityEngine;
using System.Collections;

public class StartLine : MonoBehaviour
{
    /*--External References--*/
    private TimeTrialGameManager timeTrialGameManager;
    private CameraController cameraController;
    private MusicPlayer musicPlayer;

    // Called before start
    public void Awake()
    {
        // Get the timeTrialGameManager
        timeTrialGameManager = FindObjectOfType<TimeTrialGameManager>();

        // Get the camera controller
        cameraController = FindObjectOfType<CameraController>();

        // Get the music player
        musicPlayer = FindObjectOfType<MusicPlayer>();
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
            // Transition to the action audio snapshot
            musicPlayer.transitionToActionSnapshot();

            // Start the game clock
            timeTrialGameManager.startGameClock();

            // Mark the game as started
            timeTrialGameManager.hasGameStarted = true;

            // Set the game camera to follow the player
            cameraController.isTrackingPlayer = true;
        }
    }

    // Draw editor gizmos
    public void OnDrawGizmos()
    {
        
    }
}
