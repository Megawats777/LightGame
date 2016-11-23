using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuHUD : MonoBehaviour
{
    // The title text object of the main menu background
    public Text mainMenuTitle;

    // Loading text object
    public Text loadingText;

    // Fade out image object
    public Image fadeOutImage;

    /*--HUD group titles--*/
    [Header("HUD Group Titles")]
    public string welcomeGroupTitle;
    public string levelSelectGroupTitle;
    public string helpGroupTitle;

    /*--HUD Groups--*/
    [Header("HUD Groups")]
    public GameObject welcomeHUDGroup;
    public GameObject levelSelectHUDGroup;
    public GameObject helpHUDGroup;

    /*--HUD Animation Controllers--*/
    [Header("HUD Animation Controllers")]
    public Animator mainMenuBackgroundAnimationController;
    public Animator fadeOutImageAnimationController;

    /*--HUD Animation Properties--*/
    [Header("HUD Animation Properties")]
    public float hudTransitionDelay = 1.0f;
    public float loadingTransitionDelay = 1.0f;

	// Use this for initialization
	void Start ()
    {
        // Enable the fade out image
        fadeOutImage.gameObject.SetActive(true);

        // Enable the welcome HUD group
        welcomeHUDGroup.SetActive(true);

        // Disable all other HUD groups
        levelSelectHUDGroup.SetActive(false);
        helpHUDGroup.SetActive(false);

        // Disable the loading text object
        loadingText.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // Set the title of the main menu background
    private void setMainMenuTitle(string title)
    {
        mainMenuTitle.text = title;
    }

    /*--Menu Background Animation Functions--*/
    
    // Transition to HUD Group
    private IEnumerator transitionToHUDGroup(GameObject groupToDisable, GameObject groupToEnable, string newHUDGroupTitle)
    {
        // Shrink the background
        shrinkMenuBackground();

        // Disable the designated group
        groupToDisable.SetActive(false);

        // Have a delay
        yield return new WaitForSeconds(hudTransitionDelay);

        // Set the title of the main menu background
        setMainMenuTitle(newHUDGroupTitle);

        // Enable the designated group
        groupToEnable.SetActive(true);

        // Expand the background
        expandMenuBackground();
    }

    // Shrink menu background
    private void shrinkMenuBackground()
    {
        mainMenuBackgroundAnimationController.SetBool("isExpanding", false);
        mainMenuBackgroundAnimationController.SetBool("isShrinking", true);
    }

    // Expand menu background
    private void expandMenuBackground()
    {
        mainMenuBackgroundAnimationController.SetBool("isExpanding", true);
        mainMenuBackgroundAnimationController.SetBool("isShrinking", false);
    }

    /*--Level Select HUD Functions--*/

    // Open the level select screen
    public void openLevelSelectScreen()
    {
        // Transition to HUD Group
        // Disable the welcome HUD Group
        // Enable the level select HUD Group
        // Set the title of the main menu to be the level select title
        StartCoroutine(transitionToHUDGroup(welcomeHUDGroup, levelSelectHUDGroup, levelSelectGroupTitle));
    }

    // Close the level select screen
    public void closeLevelSelectScreen()
    {
        // Transition to HUD Group
        // Disable the level select HUD Group
        // Enable the welcome HUD Group
        // Set the title of the main menu to be the welcome title
        StartCoroutine(transitionToHUDGroup(levelSelectHUDGroup, welcomeHUDGroup, welcomeGroupTitle));
    }

    /*--Help Group HUD Functions--*/

    // Open the help screen
    public void openHelpScreen()
    {
        StartCoroutine(transitionToHUDGroup(welcomeHUDGroup, helpHUDGroup, helpGroupTitle));
    }

    // Close the help screen
    public void closeHelpScreen()
    {
        StartCoroutine(transitionToHUDGroup(helpHUDGroup, welcomeHUDGroup, welcomeGroupTitle));
    }

    // Load a level
    public void loadLevel(string levelName)
    {
        // Transition to the selected level
        StartCoroutine(transitionToSelectedLevel(levelName));
    }

    // Transition to the selected level
    private IEnumerator transitionToSelectedLevel(string name)
    {
        // Shrink the menu background
        shrinkMenuBackground();

        // Show loading text object
        loadingText.gameObject.SetActive(true);

        yield return new WaitForSeconds(loadingTransitionDelay);

        // Open the level
        SceneManager.LoadSceneAsync(name);
    }

}
