﻿using UnityEngine;
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

    // Finish Text object
    public Text finishText;

    /*--Info Panel HUD Objects--*/
    [Header("Info Panel HUD Objects")]

    // The Info Panel Title
    public Text infoPanelTitle;

    // HUD Groups
    [Header("HUD Groups")]
    public GameObject clockTextGroup;
    public GameObject lightsRestoredGroup;
    public GameObject finishTextGroup;
    public GameObject infoPanelGroup;

    // UI Animation Controllers
    [Header("UI Animation Controllers")]
    public Animator finishTextAnimator;
    public Animator infoPanelAnimator;

    // UI Animation Properties
    [Header("UI Animation Properties")]
    public float finishTextOpenDelay = 2.0f;
    public float finishTextCloseDelay = 2.0f;
    public float infoPanelOpenDelay = 10.0f;

    /*--External References--*/
    private GameObject timeTrialGameManagerObject;

    // Called before start
    public void Awake()
    {
        // Get the timeTrialGameManager Gameobject
        timeTrialGameManagerObject = FindObjectOfType<TimeTrialGameManager>().gameObject;
    }

    // Use this for initialization
    void Start()
    {
        // Enable all HUD Groups
        enableAllHUDGroups();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Enable all HUD objects
    private void enableAllHUDGroups()
    {
        clockTextGroup.SetActive(true);
        lightsRestoredGroup.SetActive(true);
        finishTextGroup.SetActive(true);
        infoPanelGroup.SetActive(true);
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

    // Update the content of the finish text object
    public void updateFinishTextContent(string message)
    {
        finishText.text = message;
    }

    // Set the title of the info panel
    public void setInfoPanelTitle(string title)
    {
        infoPanelTitle.text = title;
    }

    /*--Open HUD Element Functions--*/

    // Open the finish text object after a delay
    public IEnumerator openFinishTextObject(float openDelay)
    {
        yield return new WaitForSeconds(openDelay);
        finishTextAnimator.SetBool("isExpanding", true);

        // Close the finish text object after a delay
        StartCoroutine(closeFinishTextObject(finishTextCloseDelay));
    }

    // Open the info panel
    public void openInfoPanel()
    {
        infoPanelAnimator.SetBool("isExpanding", true);
        infoPanelAnimator.SetBool("isShrinking", false);
    }

    /*--Close HUD Element Functions--*/

    // Close the finish text object after a delay
    private IEnumerator closeFinishTextObject(float closeDelay)
    {
        // Delay closing the object by a set amount
        yield return new WaitForSeconds(closeDelay);
        finishTextAnimator.SetBool("isExpanding", false);

        // After a delay show the info panel
        yield return new WaitForSeconds(infoPanelOpenDelay);
        openInfoPanel();
    }

    // Close the info panel
    private void closeInfoPanel()
    {
        infoPanelAnimator.SetBool("isExpanding", false);
        infoPanelAnimator.SetBool("isShrinking", true);
    }

}
