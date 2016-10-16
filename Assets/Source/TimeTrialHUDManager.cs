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

    // Medal target text objects
    public Text goldMedalText;
    public Text silverMedalText;
    public Text bronzeMedalText;

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
    public void updateLightsRestoredHUD(string currentLightsRestored)
    {
        lightsRestoredText.text = currentLightsRestored;
    }

    // Update medal target HUD
    public void updateMedalTargetHUD(string goldMedalTarget, string silverMedalTarget, string bronzeMedalTarget)
    {
        // Set the content of the medal target text objects
        goldMedalText.text = goldMedalTarget;
        silverMedalText.text = silverMedalTarget;
        bronzeMedalText.text = bronzeMedalTarget;
    }
}
