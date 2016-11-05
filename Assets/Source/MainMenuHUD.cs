using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuHUD : MonoBehaviour
{
    // The title text object of the main menu background
    public Text mainMenuTitle;

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

    /*--HUD Animation Properties--*/
    [Header("HUD Animation Properties")]
    public float hudTransitionDelay = 1.0f;

	// Use this for initialization
	void Start ()
    {
        // Enable the welcome HUD group
        welcomeHUDGroup.SetActive(true);

        // Disable all other HUD groups
        levelSelectHUDGroup.SetActive(false);
        helpHUDGroup.SetActive(false);
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
        mainMenuBackgroundAnimationController.SetBool("isExpanding", false);
        mainMenuBackgroundAnimationController.SetBool("isShrinking", true);

        // Disable the designated group
        groupToDisable.SetActive(false);

        // Have a delay
        yield return new WaitForSeconds(hudTransitionDelay);

        // Set the title of the main menu background
        setMainMenuTitle(newHUDGroupTitle);

        // Enable the designated group
        groupToEnable.SetActive(true);

        // Expand the background
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
}
