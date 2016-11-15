using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour
{
    /*--External References--*/
    private TimeTrialGameManager timeTrialGameManager;
    private MusicPlayer musicPlayer;

    // Called before start
    public void Awake()
    {
        // Get the timeTrialGameManager
        timeTrialGameManager = FindObjectOfType<TimeTrialGameManager>();

        // Get the music player
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // When an object overlaps the trigger
    public void OnTriggerEnter(Collider other)
    {
        // If the overlaping object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // End the game
            timeTrialGameManager.endGame();
        }
    }

    // Draw editor gizmos
    public void OnDrawGizmos()
    {
        
    }
}
