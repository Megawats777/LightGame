using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Movement axis values
    private float axisVertical = 0.0f;
    private float axisHorizontal = 0.0f;

    // Movement speed
    public float movementSpeed = 20.0f;

    // Can the player move
    private bool canMove = false;

    // Reference to the rigid body component
    private Rigidbody playerRigidBody;

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
        // Rotate player
        rotatePlayer();

        // Set if the player can move
        setCanMove();
    }

    // Called before physics calculations
    public void FixedUpdate()
    {
        // Move the player
        movePlayer();
    }

    // Rotate player
    private void rotatePlayer()
    {
       
    }

    // Set if the player can move
    private void setCanMove()
    {
        // If on PC
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            // If the move button is pressed
            if (Input.GetButtonDown("Move"))
            {
                canMove = true;
            }

            // If the move button is released
            else if (Input.GetButtonUp("Move"))
            {
                canMove = false;
            }
        }

        // If on android
        if (Application.platform == RuntimePlatform.Android)
        {
            // If the user touches the screen move the player
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                canMove = true;
            }

            // If the user stops touching the screen stop moving the player
            else if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            {
                canMove = false;
            }
        }
    }

    // Move the player
    private void movePlayer()
    {
        // If the player can move
        if (canMove)
        {
            // Add forces to the player on the y-axis
            playerRigidBody.AddRelativeForce(new Vector3(0.0f, movementSpeed, 0.0f));
        }
    }
}
