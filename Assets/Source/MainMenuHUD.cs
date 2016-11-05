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

    /*--Level Select HUD Functions--*/

    // Open the level select screen
    public void openLevelSelectScreen()
    {
        // Set the title of the main menu background
        setMainMenuTitle(levelSelectGroupTitle);

        // Disable the welcome HUD group
        welcomeHUDGroup.SetActive(false);

        // Set the level select HUD group to be active
        levelSelectHUDGroup.SetActive(true);
    }

    // Close the level select screen
    public void closeLevelSelectScreen()
    {
        // Set the title of the main menu background
        setMainMenuTitle(welcomeGroupTitle);

        // Enable the welcome HUD group
        welcomeHUDGroup.SetActive(true);

        // Disable the level select HUD group
        levelSelectHUDGroup.SetActive(false);
    }
}
