using UnityEngine;
using System.Collections;

public class LightCheckpoint : MonoBehaviour
{
    // The activated light brightness
    private float activateTargetLightBrightness = 0.0f;

    // Target checkpoint light brightness
    private float lightTargetBrightness = 0.0f;

    // The brightness change speed
    public float lightBrightnessChangeSpeed = 5.0f;

    // The particle system to play when activated
    [SerializeField]
    private GameObject activatedParticleSystem;

    // Reference to the sphere collider component
    private SphereCollider checkpointCollider;

    // Reference to the light component
    private Light checkpointLight;

    // Reference to the checkpoint mesh
    private Renderer checkpointMesh;

    // Reference to the boost checkpoint class
    private BoostCheckpoint boostCheckpoint;

    /*--External References--*/
    TimeTrialGameManager timeTrialGameManager;

    [SerializeField]
    private TrackScenery[] trackSceneryObjects;

    // Called before start
    public void Awake()
    {
        // Get the sphere collider component
        checkpointCollider = GetComponent<SphereCollider>();

        // Get the light component
        checkpointLight = GetComponent<Light>();

        // Get the checkpoint mesh renderer
        checkpointMesh = GetComponentInChildren<Renderer>();

        // Get the boost checkpoint class
        boostCheckpoint = GetComponent<BoostCheckpoint>();

        // Get the timeTrialGameManager
        timeTrialGameManager = FindObjectOfType<TimeTrialGameManager>();
    }

    // Use this for initialization
    void Start()
    {
        // Set the colour of the checkpoint mesh to be the same as the checkpoint light
        checkpointMesh.material.EnableKeyword("_EMISSION");
        checkpointMesh.material.SetColor("_EmissionColor", checkpointLight.color);

        // Set the activated light brightness
        activateTargetLightBrightness = checkpointLight.intensity;

        // Set the brightness of the light to be zero
        checkpointLight.intensity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Set light intensity
        setLightIntensity();
    }

    // Set light intensity
    private void setLightIntensity()
    {
        // Blend the checkpoint light brightness to the target brightness
        checkpointLight.intensity = Mathf.Lerp(checkpointLight.intensity, lightTargetBrightness, Time.deltaTime * lightBrightnessChangeSpeed);
    }

    // When an object overlaps with the object
    public void OnTriggerEnter(Collider other)
    {
        // If the overlaping object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Disable the checkpoint mesh
            checkpointMesh.enabled = false;

            // Disable the sphere collider
            checkpointCollider.enabled = false;

            // If the light checkpoint has the tag "Checkpoint"
            if (gameObject.CompareTag("Checkpoint"))
            {
                // Increase the number of lights restored
                timeTrialGameManager.setLightCheckpointsRestoredAmount(timeTrialGameManager.getLightCheckpointsRestoredAmount() + 1);
            }

            // If the boost checkpoint class exists
            if (boostCheckpoint)
            {
                // The Player object reference
                PlayerController player = other.gameObject.GetComponent<PlayerController>();

                // Add force to the player
                boostCheckpoint.boostObject(player);
            }

            // Restore track scenery objects
            restoreTrackSceneryObjects();

            // Spawn particle system
            spawnParticleSystem();

            // Set the target light brightness to the activated light brightness
            lightTargetBrightness = activateTargetLightBrightness;
        }
    }

    // Restore track scenery objects
    private void restoreTrackSceneryObjects()
    {
        // If the list of track scenery objects is greater than 0
        if (trackSceneryObjects.Length > 0)
        {
            // For each track scenery object
            foreach (TrackScenery scenery in trackSceneryObjects)
            {
                // Set the track scenery object to a restored state
                scenery.restoreObject();
            }
        }
    }

    // Spawn particle system
    private void spawnParticleSystem()
    {
        // Spawn the object
        GameObject spawnedParticleSystem = (GameObject)Instantiate(activatedParticleSystem, transform.position, Quaternion.identity);

        // Get the particle system component
        ParticleSystem particleSystem = spawnedParticleSystem.GetComponent<ParticleSystem>();

        // If the particle system component exists
        if (particleSystem)
        {
            // Set the colour of the particle system
            particleSystem.startColor = checkpointLight.color;
        }
    }
}
