using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Movement axis values
    private float axisVertical = 0.0f;
    private float axisHorizontal = 0.0f;

    // Movement speed
    public float movementSpeed = 20.0f;

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
        // Set the movement axis values
        setMovementAxisValues();
    }

    // Called before physics calculations
    public void FixedUpdate()
    {
        // Move the player
        movePlayer();
    }

    // Set the movement axis values
    private void setMovementAxisValues()
    {
        // If the move up or move down buttons are pressed adjust the vertical axis values
        if (Input.GetButton("MoveUp"))
        {
            axisVertical = 1.0f;
        }
        else if (Input.GetButton("MoveDown"))
        {
            axisVertical = -1.0f;
        }
        else
        {
            axisVertical = 0.0f;
        }

        // If the move left or move right buttons are pressed adjust the horizontal axis values
        if (Input.GetButton("MoveRight"))
        {
            axisHorizontal = 1.0f;
        }
        else if (Input.GetButton("MoveLeft"))
        {
            axisHorizontal = -1.0f;
        }
        else
        {
            axisHorizontal = 0.0f;
        }
    }

    // Move the player
    private void movePlayer()
    {
        // Add forces to the player based on the axis values
        playerRigidBody.AddForce(new Vector3(movementSpeed * axisHorizontal, movementSpeed * axisVertical, 0.0f));
    }
}
