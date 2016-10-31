using UnityEngine;
using System.Collections;

public class SpeedBlock : MonoBehaviour
{
    // The object's rotation rate
    [SerializeField]
    private Vector3 rotationRate;

    // Explosion particle effect
    [SerializeField, Tooltip("Particle effect to spawn when this speed block is destoryed")]
    private GameObject explosionParticleEffect;

    // Reference to the rigidbody component
    private Rigidbody objectRigidBody;

    // Reference to the mesh renderer
    private Renderer meshRenderer;

    // Reference to the collider
    private Collider objectCollider;

    // Reference to the speedblock point light component
    private Light speedBlockPointLight;

    /*--External References--*/
    TimeTrialHUDManager timeTrialHUDManager;
    PlayerController player;
    CameraController gameCamera;

    // Called before start
    public void Awake()
    {
        // Get the rigidbody component
        objectRigidBody = GetComponent<Rigidbody>();

        // Get the mesh renderer
        meshRenderer = GetComponent<Renderer>();

        // Ge the object's collider
        objectCollider = GetComponent<Collider>();

        // Get the speedblock point light component
        speedBlockPointLight = GetComponentInChildren<Light>();

        // Get the timeTrialHUDManager
        timeTrialHUDManager = FindObjectOfType<TimeTrialHUDManager>();

        // Get the player
        player = FindObjectOfType<PlayerController>();

        // Get the game camera
        gameCamera = FindObjectOfType<CameraController>();
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

            // Shake the camera
            StartCoroutine(gameCamera.shakeCamera());

            // Stun the player
            StartCoroutine(stunPlayer());

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

        // Disable the speedblock point light effect
        speedBlockPointLight.enabled = false;

        // Play a sound effect

        // Spawn a particle effect
        spawnParticleEffect();
    }

    // Stun the player
    private IEnumerator stunPlayer()
    {
        // Show the stunned text object
        if (timeTrialHUDManager)
        {
            timeTrialHUDManager.setStunnedTextVisibility(true);
        }

        // Set the rigidbody component to be kinematic
        player.playerRigidBody.isKinematic = true;

        yield return new WaitForSeconds(player.stunRecoveryDelay);

        // Hide the stunned text object
        if (timeTrialHUDManager)
        {
            timeTrialHUDManager.setStunnedTextVisibility(false);
        }

        // Set the rigidbody component to not be kinematic
        player.playerRigidBody.isKinematic = false;
    }

    // Spawn particle effect
    private void spawnParticleEffect()
    {
        // Is the particle effect exists
        if (explosionParticleEffect)
        {
            // Particle effect spawn location
            Vector3 particleEffectSpawnLocation = player.transform.position;

            Instantiate(explosionParticleEffect, particleEffectSpawnLocation, Quaternion.identity);
        }
    }
}
