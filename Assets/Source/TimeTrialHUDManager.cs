using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimeTrialHUDManager : MonoBehaviour
{
    // Fade image
    public Image fadeImage;

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

    // Stunned Text object
    public Text stunnedText;

    /*--Info Panel HUD Objects--*/
    [Header("Info Panel HUD Objects")]

    // The Info Panel Title
    public Text infoPanelTitle;

    /*--Info Panel HUD Groups--*/
    [Header("Info Panel HUD Groups")]
    public GameObject gameplayHUDGroup;
    public GameObject pauseInfoGroup;
    public GameObject gameSummaryInfoGroup;

    /*--Info Panel Pause HUD Objects--*/
    [Header("Info Panel Pause Screen HUD Objects")]
    public Text timeRemaingingInfoTextPaused;
    public Text lightsRestoredInfoTextPaused;

    /*--Info Panel Game Summary HUD Objects--*/
    [Header("Info Panel Game Summary HUD Objects")]
    public Text timeRemainingInfoText;
    public Text lightsRestoredInfoText;
    public Text medalAwardedText;
    public RawImage medalAwardedImage;

    /*--Info Panel Game Summary HUD Properties--*/
    [Header("Info Panel Game Summary HUD Properties")]
    public string goldMedalMessage = "Gold Medal Awarded";
    public string silverMedalMessage = "Silver Medal Awarded";
    public string bronzeMedalMessage = "Bronze Medal Awarded";

    [HideInInspector]
    public string medalMessage = null;

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
    public Animator fadeImageAnimator;

    // UI Animation Properties
    [Header("UI Animation Properties")]
    public float finishTextOpenDelay = 2.0f;
    public float finishTextCloseDelay = 2.0f;
    public float infoPanelOpenDelay = 10.0f;

    /*--External References--*/
    private TimeTrialGameManager timeTrialGameManager;
    private PlayerController player;
    private CameraController gameCamera;
    private MusicPlayer musicPlayer;

    // Called before start
    public void Awake()
    {
        // Get the timeTrialGameManager Gameobject
        timeTrialGameManager = FindObjectOfType<TimeTrialGameManager>();

        // Get the player controller
        player = FindObjectOfType<PlayerController>();

        // Get the gameCamera
        gameCamera = FindObjectOfType<CameraController>();

        // Get the music player
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    // Use this for initialization
    void Start()
    {
        // Enable the fade image
        fadeImage.gameObject.SetActive(true);

        // Enable all HUD Groups
        enableAllHUDGroups();

        // Disable all Info Panel HUD Groups
        disableInfoPanelHUDGroups();

        // Hide the stunned text object
        setStunnedTextVisibility(false);
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

    // Disable all Info Panel HUD Groups
    private void disableInfoPanelHUDGroups()
    {
        pauseInfoGroup.SetActive(false);
        gameSummaryInfoGroup.SetActive(false);
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

    // Set the visibility of the stunned text object
    public void setStunnedTextVisibility(bool status)
    {
        stunnedText.gameObject.SetActive(status);
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
    public void closeInfoPanel()
    {
        infoPanelAnimator.SetBool("isExpanding", false);
        infoPanelAnimator.SetBool("isShrinking", true);
    }

    /*-----Gameplay HUD Group Functions------*/

    // Set the visibility of the gameplay HUD Group
    public void setGameplayHUDGroupVisibility(bool status)
    {
        gameplayHUDGroup.SetActive(status);
    }

    /*----Info Panel Functions----*/

    /*--Info Panel Game Summary Functions--*/

    // Show the game summary HUD
    public void showGameSummaryHUD(string timeRemainingSTR, string lightsRestoredSTR, string medalAwardedSTR, Texture2D medalImage)
    {
        // Disable the pause screen info group
        pauseInfoGroup.SetActive(false);

        // Set the game summary HUD to be active
        gameSummaryInfoGroup.SetActive(true);

        // Set the title of the info panel
        infoPanelTitle.text = "Game Over";

        // Set the content of the time remaining text
        timeRemainingInfoText.text = timeRemainingSTR;

        // Set the content of the lights restored text
        lightsRestoredInfoText.text = lightsRestoredSTR;

        // Set the content of the medal awarded text
        medalAwardedText.text = medalAwardedSTR;

        // Set the medal awarded image
        medalAwardedImage.texture = medalImage;
    }

    // Close the game summary HUD
    public void closeGameSummaryHUD()
    {
        gameSummaryInfoGroup.SetActive(false);
    }

    // Set medal awarded message
    public void setMedalAwardedMessage(string message)
    {
        medalMessage = message;
    }

    /*--Info Panel Pause Screen Functions--*/

    // Show pause screen HUD
    public void showPauseScreenHUD()
    {
        // Set the title of the info panel
        infoPanelTitle.text = "Game Paused";

        // Disable the game summary info panel group
        gameSummaryInfoGroup.SetActive(false);

        // Enable the pause screen info panel group
        pauseInfoGroup.SetActive(true);

        // Update time remaining pause screen text
        updateTimeRemainingPauseText();

        // Update lights restored pause screen text
        updateLightsRestoredPauseText();
    }

    // Update time remaining pause screen text
    private void updateTimeRemainingPauseText()
    {
        timeRemaingingInfoTextPaused.text = timeTrialGameManager.getGameClockLength().ToString();
    }

    // Update lights restored pause screen text
    private void updateLightsRestoredPauseText()
    {
        lightsRestoredInfoTextPaused.text = timeTrialGameManager.getLightCheckpointsRestoredAmount().ToString();
    }

    /*--TimeTrialGameManager Wrapper Functions--*/

    // Unpause wrapper functions
    public void unPauseWrapper()
    {
        timeTrialGameManager.UnpauseGame();
    }

    /*--Fade Image Functions--*/

    // Fade the screen
    private void fadeScreen()
    {
        fadeImageAnimator.SetBool("isFadingIn", true);
    }

    /*--Loading Level Functions--*/

    // Load a level by name
    public void loadLevelByName(string levelName)
    {
        // Transition to a level
        StartCoroutine(transitionToLevel(levelName));
    }

    // Load the current level
    public void loadCurrentLevel()
    {
        // Transition to a level
        StartCoroutine(transitionToLevel(SceneManager.GetActiveScene().name));
    }

    // Transition to a level
    private IEnumerator transitionToLevel(string name)
    {
        // Set the time scale to be 1
        Time.timeScale = 1.0f;

        // End the game clock
        timeTrialGameManager.endGameClock();

        // Pause the player
        player.pausePlayer();

        // Stop the game camera from following the player
        CameraController gameCamera = FindObjectOfType<CameraController>();
        gameCamera.isTrackingPlayer = false;

        // Stop the game camera from shaking
        gameCamera.isCameraShaking = false;

        // Transition to the muted music audio state
        musicPlayer.transitionToMutedSnapShot();

        // Stop all rotating objects from rotating
        foreach (RotatingObject ro in FindObjectsOfType<RotatingObject>())
        {
            if (ro)
            {
                ro.canRotate = false;
            }
        }

        // Pause all particle systems
        foreach (ParticleSystem particleSystem in FindObjectsOfType<ParticleSystem>())
        {
            if (particleSystem)
            {
                particleSystem.Pause();
            }
        }

        // Shrink the info panel
        closeInfoPanel();

        // Fade the screen
        fadeScreen();

        // Show the loading text object

        yield return new WaitForSeconds(1.0f);

        // Load the level
        SceneManager.LoadSceneAsync(name);
    }
}
