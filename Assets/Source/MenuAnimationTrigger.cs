using UnityEngine;
using System.Collections;

public class MenuAnimationTrigger : MonoBehaviour
{
    // Animator component
    public Animator animatorComponent;

    // Names of boolean animation paramater
    public string[] animationParameterNames;

    // Set status of boolean animation parameters
    public bool[] boolAnimationParameterStatus;

    // Called before start
    public void Awake()
    {
        // Get the animator component
        animatorComponent = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set boolean animation parameter
    public void setBoolAnimationParameter(int index)
    {
        animatorComponent.SetBool(animationParameterNames[index], boolAnimationParameterStatus[index]);
    }
}
