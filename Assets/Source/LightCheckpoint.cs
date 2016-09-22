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

    // Reference to the light component
    private Light checkpointLight;

    // Called before start
    public void Awake()
    {
        // Get the light component
        checkpointLight = GetComponent<Light>();
    }

    // Use this for initialization
    void Start()
    {
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
            // Set the target light brightness to the activated light brightness
            lightTargetBrightness = activateTargetLightBrightness;
        }
    }
}
