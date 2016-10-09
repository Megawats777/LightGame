using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeTrialHUDManager : MonoBehaviour
{
    /*--Gameplay HUD Objects--*/
    [Header("Gameplay HUD Objects")]

    // Game clock text objects
    public Text clockTitle;
    public Text clockText;

    // Lights restored text objects
    public Text lightsRestoredTitle;
    public Text lightsRestoredText;

    public Text winLoseText;

	// Use this for initialization
	void Start ()
    {
        // Set the content of the winLoseText to null
        winLoseText.text = "";	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // Update the game clock HUD
    public void updateGameClockHUD(string content)
    {
        clockText.text = content;
    }

    // Update the lights restored HUD
    public void updateLightsRestoredHUD(string currentLightsRestored, string lightCheckpointAmountString)
    {
        lightsRestoredText.text = currentLightsRestored + "/" + lightCheckpointAmountString;
    }
}
