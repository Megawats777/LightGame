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

    /*--Pause Properties--*/
    [Header("Pause Properties")]
    public bool isGamePaused = false;
    public bool playerCanPauseGame = true;

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

    // Pause the game
    public void pauseGame()
    {
        // Set the time scale to be 0
        Time.timeScale = 0.0f;

        // Set the game as paused
        isGamePaused = true;

        // Set the player cannot pause the game
        playerCanPauseGame = false;

        // Stop the game clock
        endGameClock();

        // Show the info panel
        timeTrialHUDManager.openInfoPanel();
    }

    // Unpause the game
    public void UnpauseGame()
    {
        // Set the time scale to be 1
        Time.timeScale = 1.0f;

        // Set the game as not paused
        isGamePaused = false;

        // Set the player can pause the game
        playerCanPauseGame = true;

        // Start the game clock
        startGameClock();

        // Show the info panel
        timeTrialHUDManager.closeInfoPanel();
    }


    // End the game
    public void endGame()
    {
        // Set the game as not paused
        isGamePaused = false;

        // Do not allow the player to pause
        playerCanPauseGame = false;

        // Stop the game clock
        endGameClock();

        // If the clock length is greater than 0
        if (clockLength > 0)
        {
            // Set the finish text message
            timeTrialHUDManager.updateFinishTextContent("Finish");

            // Open the finish text object
            StartCoroutine(timeTrialHUDManager.openFinishTextObject(timeTrialHUDManager.finishTextOpenDelay));

            // Check medal targets were achieved
            checkMedalTargets();

            // Set the title of the info panel
            timeTrialHUDManager.setInfoPanelTitle("Game Over");

            // Show game summary info group
            timeTrialHUDManager.showGameSummaryHUD(clockLength.ToString(), lightCheckpointsRestored.ToString(), timeTrialHUDManager.medalMessage, null);

        }

        // If the clock length is 0
        else if (clockLength == 0)
        {
            // Set the finish text message
            timeTrialHUDManager.updateFinishTextContent("Time Up");

            // Set the title of the info panel
            timeTrialHUDManager.setInfoPanelTitle("Game Over");

            // Open the finish text object
            StartCoroutine(timeTrialHUDManager.openFinishTextObject(timeTrialHUDManager.finishTextOpenDelay));

            // Show game summary info group
            timeTrialHUDManager.showGameSummaryHUD(clockLength.ToString(), lightCheckpointsRestored.ToString(), "No Medal Awarded", null);
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

            // Set the medal awarded message
            timeTrialHUDManager.setMedalAwardedMessage(timeTrialHUDManager.goldMedalMessage);
        }

        // If the player earned a silver medal
        else if (lightCheckpointsRestored >= silverMedalTarget && lightCheckpointsRestored < goldMedalTarget)
        {
            Debug.Log("You won the silver medal");

            // Set the medal awarded message
            timeTrialHUDManager.setMedalAwardedMessage(timeTrialHUDManager.silverMedalMessage);
        }

        // If the player earned a bronze medal
        else if (lightCheckpointsRestored >= bronzeMedalTarget && lightCheckpointsRestored < silverMedalTarget)
        {
            Debug.Log("You won the bronze medal");

            // Set the medal awarded message
            timeTrialHUDManager.setMedalAwardedMessage(timeTrialHUDManager.bronzeMedalMessage);
        }

        // Otherwise
        else
        {
            // Set the medal awarded message
            timeTrialHUDManager.setMedalAwardedMessage("No Medal Awarded");
        }
    }
}
