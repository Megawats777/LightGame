using UnityEngine;
using System.Collections;

public class TimeCheckpoint : MonoBehaviour
{
    // Game clock time increase amount
    public int gameClockIncreaseAmount = 10;

    /*--External References--*/
    TimeTrialGameManager timeTrialGameManager;

    // Called before start
    public void Awake()
    {
        // Get the timeTrialGameManager
        timeTrialGameManager = FindObjectOfType<TimeTrialGameManager>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // When an object overlaps with this gameobject
    public void OnTriggerEnter(Collider other)
    {
        // If the overlapping object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Add to the game clock length
            timeTrialGameManager.setGameClockLength(timeTrialGameManager.getGameClockLength() + gameClockIncreaseAmount);
        }
    }
}
