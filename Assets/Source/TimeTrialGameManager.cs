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

    /*--Medal Targets--*/
    [Header("Medal Targets")]
    public int goldMedalTarget = 0;
    public int silverMedalTarget = 5;
    public int bronzeMedalTarget = 3;

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

        // Set the gold medal target to be the same as the light checkpoint amount
        goldMedalTarget = lightCheckpointAmount;

        // Update the medal target HUD
        timeTrialHUDManager.updateMedalTargetHUD(goldMedalTarget.ToString(), silverMedalTarget.ToString(), bronzeMedalTarget.ToString());
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
        timeTrialHUDManager.updateLightsRestoredHUD(lightCheckpointsRestored.ToString());
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
            endGame();   
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
        timeTrialHUDManager.updateLightsRestoredHUD(lightCheckpointsRestored.ToString());
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
    public void endGame()
    {
        // Stop the game clock
        endGameClock();

        // If the clock length is greater than 0
        if (clockLength > 0)
        {
            timeTrialHUDManager.winLoseText.text = "You Win";

            // Check medal targets were achieved
            checkMedalTargets();
        }

        // If the clock length is 0
        else if (clockLength == 0)
        {
            timeTrialHUDManager.winLoseText.text = "Game Over";
        }

        // Disable the player
        player.disablePlayer();
    }

    // Check medal targets were achieved
    private void checkMedalTargets()
    {
        // If the player earned a gold medal
        if (lightCheckpointsRestored == goldMedalTarget)
        {
            Debug.Log("You won the gold medal");
        }

        // If the player earned a silver medal
        else if (lightCheckpointsRestored >= silverMedalTarget && lightCheckpointsRestored < goldMedalTarget)
        {
            Debug.Log("You won the silver medal");
        }

        // If the player earned a bronze medal
        else if (lightCheckpointsRestored >= bronzeMedalTarget && lightCheckpointsRestored < silverMedalTarget)
        {
            Debug.Log("You won the bronze medal");
        }
    }
}
