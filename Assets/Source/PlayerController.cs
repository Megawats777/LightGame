using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Movement axis values
    public float axisVertical = 0.0f;
    public float axisHorizontal = 0.0f;

    // Movement speed properties
    [Header("Movement Speed Properties")]
    public float movementSpeed = 20.0f;
    public float speedBlendTime = 50.0f;
    private float targetMovementSpeed = 0.0f;
    private float defaultMovementSpeed = 0.0f;

    // Can the player move
    private bool canMove = true;

    // Reference to the rigid body component
    [HideInInspector]
    public Rigidbody playerRigidBody;

    // Reference to the renderer component
    private Renderer playerRenderer;

    // Reference to the particle trail
    private ParticleSystem particleTrail;

    // Reference to the sphere light
    private Light sphereLight;


    /*--External References--*/
    TimeTrialGameManager timeTrialGameManager;

    // Called before start
    public void Awake()
    {
        // Get the rigid body component
        playerRigidBody = GetComponent<Rigidbody>();

        // Get the renderer component
        playerRenderer = GetComponent<Renderer>();

        // Get the particle trail
        particleTrail = GetComponentInChildren<ParticleSystem>();

        // Get the sphere light
        sphereLight = GetComponentInChildren<Light>();

        // Get the timeTrialGameManager
        timeTrialGameManager = FindObjectOfType<TimeTrialGameManager>();
    }

    // Use this for initialization
    void Start()
    {
        // Set the default movement speed
        defaultMovementSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Set movement axis values
        setMovementAxisValues();

        // Blend movement speed values
        blendMovementSpeedValues();

        // Control pause state
        controlPauseState();
    }

    // Called before physics calculations
    public void FixedUpdate()
    {
        // Move the player
        movePlayer();
    }

    // Control pause state
    private void controlPauseState()
    {
        // If the pause button is pressed
        if (Input.GetButtonDown("Pause"))
        {
            // If the timeTrialGameManager exists
            if (timeTrialGameManager)
            {
                // If the game is not paused and the player can pause then pause the game
                if (timeTrialGameManager.isGamePaused == false && timeTrialGameManager.playerCanPauseGame == true)
                {
                    timeTrialGameManager.pauseGame();
                }

                // If the game is paused and the player cannot pause then unpause the game
                else if (timeTrialGameManager.isGamePaused == true && timeTrialGameManager.playerCanPauseGame == false)
                {
                    timeTrialGameManager.UnpauseGame();
                }
            }
        }
    }

    // Set movement axis values
    private void setMovementAxisValues()
    {
        // Set the vertical axis values
        if (Input.GetButton("MoveUp"))
        {
            axisVertical = 1.0f;
        }
        else if (Input.GetButton("MoveDown"))
        {
            axisVertical = -1.0f;
        }
        else if (Input.GetButton("MoveUp") && Input.GetButton("MoveDown"))
        {
            axisVertical = 0.0f;
        }
        else
        {
            axisVertical = 0.0f;
        }

        // Set the horizontal axis values
        if (Input.GetButton("MoveRight"))
        {
            axisHorizontal = 1.0f;
        }
        else if (Input.GetButton("MoveLeft"))
        {
            axisHorizontal = -1.0f;
        }
        else if (Input.GetButton("MoveRight") && Input.GetButton("MoveLeft"))
        {
            axisHorizontal = 0.0f;
        }
        else
        {
            axisHorizontal = 0.0f;
        }
    }

    // Blend movement speed values
    private void blendMovementSpeedValues()
    {
        movementSpeed = Mathf.Lerp(movementSpeed, defaultMovementSpeed, Time.deltaTime * speedBlendTime);
    }

    // Move the player
    private void movePlayer()
    {
        // If the player can move
        if (canMove)
        {
            // Add forces to the player on the y-axis
            playerRigidBody.AddForce(new Vector3(movementSpeed * axisHorizontal, movementSpeed * axisVertical, 0.0f));
        }
    }

    // Disable the player
    public void disablePlayer()
    {
        // Set can move to false and set the player rigidbody to be kinematic
        canMove = false;
        playerRigidBody.isKinematic = true;

        // Disable the player renderer
        playerRenderer.enabled = false;

        // Disable the sphere light and particle trail
        sphereLight.enabled = false;
        particleTrail.loop = false;
        particleTrail.startLifetime = 0.0f;
    }
}
