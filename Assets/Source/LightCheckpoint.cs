﻿using UnityEngine;
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

    // Called before start
    public void Awake()
    {
        // Get the sphere collider component
        checkpointCollider = GetComponent<SphereCollider>();

        // Get the light component
        checkpointLight = GetComponent<Light>();

        // Get the checkpoint mesh
        checkpointMesh = GetComponentInChildren<Renderer>();

        // Get the boost checkpoint class
        boostCheckpoint = GetComponent<BoostCheckpoint>();
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

            // If the boost checkpoint class exists
            if (boostCheckpoint)
            {
                // The rigidbody of the player
                Rigidbody rigidBody = other.gameObject.GetComponent<Rigidbody>();

                // Add force to the player
                boostCheckpoint.boostObject(rigidBody);
            }

            // Spawn particle system
            spawnParticleSystem();

            // Set the target light brightness to the activated light brightness
            lightTargetBrightness = activateTargetLightBrightness;
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
