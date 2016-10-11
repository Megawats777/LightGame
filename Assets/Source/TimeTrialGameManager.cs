using UnityEngine;
using System.Collections;

public class TimeTrialGameManager : MonoBehaviour
{
    /*--Game Clock Properties--*/
    [Header("Game Clock Properties"),SerializeField]
    private int clockLength = 30;

    /*--Light Checkpoint Collection Properties*/
    [Header("Light Checkpoint Collection Properties")]
    public int lightCheckpointsRestored = 0;
    private int lightCheckpointAmount = 0;

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
        // Set the light checkpoint amount
        setLightCheckpointAmount();

        // Update the game clock HUD
        timeTrialHUDManager.updateGameClockHUD(clockLength.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set the light checkpoint amount
    private void setLightCheckpointAmount()
    {
        // For each game object with the tag "Checkpoint" increase the light checkpoint amount
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Checkpoint"))
        {
            lightCheckpointAmount++;
        }

        // Update the lights restored HUD
        timeTrialHUDManager.updateLightsRestoredHUD(lightCheckpointsRestored.ToString(), lightCheckpointAmount.ToString());
    }

    // Run the game clock
    private void runGameClock()
    {
        // Decrement the clock length
        clockLength--;

        // Update the game clock HUD
        timeTrialHUDManager.updateGameClockHUD(clockLength.ToString());

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

    // Get the light checkpoints restored amount
    public int getLightCheckpointsRestoredAmount()
    {
        return lightCheckpointsRestored;
    }
    
    // Set the light checkpoints restored amount
    public void setLightCheckpointsRestoredAmount(int amount)
    {
        // Set the light checkpoints restored amount value 
        lightCheckpointsRestored = amount;

        // Update the lights restored HUD
        timeTrialHUDManager.updateLightsRestoredHUD(lightCheckpointsRestored.ToString(), lightCheckpointAmount.ToString());
    }

    // Get the game clock length
    public int getGameClockLength()
    {
        return clockLength;
    }

    // Set the game clock length
    public void setGameClockLength(int length)
    {
        clockLength = length;

        // Update the game clock HUD
        timeTrialHUDManager.updateGameClockHUD(clockLength.ToString());
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

            // Dim all track scenery objects
            foreach (TrackScenery scenery in FindObjectsOfType<TrackScenery>())
            {
                scenery.disableObject();
            }
        }
        
        // Disable the player
        player.disablePlayer();
    }
}
