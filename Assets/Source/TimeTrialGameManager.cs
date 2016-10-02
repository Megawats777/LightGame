using UnityEngine;
using System.Collections;

public class TimeTrialGameManager : MonoBehaviour
{
    /*--Game Clock Properties--*/
    [SerializeField]
    private int clockLength = 30;


    /*--External References--*/
    private TimeTrialHUDManager timeTrialHUDManager;
    private PlayerController player;

    // Called before start
    public void Awake()
    {
        // Get the timeTrialHUDManger
        timeTrialHUDManager = FindObjectOfType<TimeTrialHUDManager>();

        // Get the player controller
        player = FindObjectOfType<PlayerController>();
    }

    // Use this for initialization
    void Start()
    {
        // Update the game clock HUD
        updateGameClockHUD();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Run the game clock
    private void runGameClock()
    {
        // Decrement the clock length
        clockLength--;

        // Update the game clock HUD
        updateGameClockHUD();

        // If the clock length is 0
        if (clockLength == 0)
        {
            // End the game
            endGame(false);   
        }
    }

    // Start the game clock
    public void startGameClock()
    {
        InvokeRepeating("runGameClock", 0.0f, 1.0f);
    }

    // End the game clock
    public void endGameClock()
    {
        CancelInvoke("runGameClock");
    }

    // Update the game clock HUD
    private void updateGameClockHUD()
    {
        // If the timeTrialHUDManger exists
        if (timeTrialHUDManager)
        {
            timeTrialHUDManager.clockText.text = clockLength.ToString();
        }
    }

    // End the game
    public void endGame(bool winStatus)
    {
        // Stop the game clock
        endGameClock();

        // Disable the clock title and clock text HUD
        timeTrialHUDManager.clockTitle.text = "";
        timeTrialHUDManager.clockText.text = "";

        // If the winStatus is true
        if (winStatus == true)
        {
            timeTrialHUDManager.winLoseText.text = "You Win";
        }

        // If the winStatus is false
        else if (winStatus == false)
        {
            timeTrialHUDManager.winLoseText.text = "Game Over";
        }
        
        // Disable the player
        player.disablePlayer();
    }
}
