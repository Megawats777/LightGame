using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Movement axis values
    private float axisVertical = 0.0f;
    private float axisHorizontal = 0.0f;

    // Movement speed
    public float movementSpeed = 20.0f;

    // Can the player move
    private bool canMove = true;

    // Reference to the rigid body component
    [HideInInspector]
    public Rigidbody playerRigidBody;

    // Called before start
    public void Awake()
    {
        // Get the rigid body component
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Set movement axis values
        setMovementAxisValues();

        // DEBUG FUNCTION
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Called before physics calculations
    public void FixedUpdate()
    {
        // Move the player
        movePlayer();
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
}
