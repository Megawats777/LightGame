using UnityEngine;
using System.Collections;

public class SpeedBlock : MonoBehaviour
{
    // The object's rotation rate
    [SerializeField]
    private Vector3 rotationRate;

    // Reference to the rigidbody component
    private Rigidbody objectRigidBody;

    // Reference to the mesh renderer
    private Renderer meshRenderer;

    // Reference to the collider
    private Collider objectCollider;

    // Called before start
    public void Awake()
    {
        // Get the rigidbody component
        objectRigidBody = GetComponent<Rigidbody>();

        // Get the mesh renderer
        meshRenderer = GetComponent<Renderer>();

        // Ge the object's collider
        objectCollider = GetComponent<Collider>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called before physics calculations
    public void FixedUpdate()
    {
        transform.Rotate(new Vector3(rotationRate.x * Time.deltaTime, rotationRate.y * Time.deltaTime, rotationRate.z * Time.deltaTime));
    }

    // When this object is overlapped
    public void OnTriggerEnter(Collider other)
    {
        // If the overlapping object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Get a reference to the player
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            // Slow down the player
            StartCoroutine(player.slowDownPlayer());

            // Disable this speed block
            disableSpeedBlock();
        }
    }

    // Disable speed block
    private void disableSpeedBlock()
    {
        // Disable speed block components
        objectCollider.enabled = false;
        meshRenderer.enabled = false;

        // Play a sound effect

        // Spawn a particle effect
    }
}
