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

    // Finish Text object
    public Text finishText;

    // UI Animation Controllers
    [Header("UI Animation Controllers")]
    public Animator finishTextAnimator;

    // UI Animation Properties
    [Header("UI Animation Properties")]
    public float finishTextOpenDelay = 2.0f;
    public float finishTextCloseDelay = 2.0f;

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
        
    }

    // Update is called once per frame
    void Update()
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

    // Update the content of the finish text object
    public void updateFinishTextContent(string message)
    {
        finishText.text = message;
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

    /*--Close HUD Element Functions--*/

    // Close the finish text object
    private IEnumerator closeFinishTextObject(float closeDelay)
    {
        // Delay closing the object by a set amount
        yield return new WaitForSeconds(closeDelay);
        finishTextAnimator.SetBool("isExpanding", false);
    }

}
