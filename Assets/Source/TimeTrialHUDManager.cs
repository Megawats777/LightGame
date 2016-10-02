using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeTrialHUDManager : MonoBehaviour
{
    /*--Gameplay HUD Objects--*/
    [Header("Gameplay HUD Objects")]
    public Text clockTitle;
    public Text clockText;
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
}
