using UnityEngine;
using System.Collections;

public class TrackScenery : MonoBehaviour
{
    // Object restored colour
    [SerializeField]
    private Color restoredColour;

    // Object colour blend speed
    [SerializeField]
    private float colourBlendSpeed = 5.0f;

    // Object opacity
    private float objectOpacity = 0.0f;

    

    // Is the object restored
    [SerializeField]
    private bool isObjectRestored = false;

    // Reference to the renderer component
    private Renderer objectRenderer;

    // Called before start
    public void Awake()
    {
        // Get the renderer component
        objectRenderer = GetComponent<Renderer>();
    }

    // Use this for initialization
    void Start()
    {
        // Enable the emissive properties keyword
        objectRenderer.material.EnableKeyword("_EMISSION");

        // Set the object to not be opaque
        objectRenderer.material.color = new Color(0.0f, 0.0f, 0.0f, objectOpacity);
    }

    // Update is called once per frame
    void Update()
    {
        // Blend object colour values
        blendObjectColourValues();
    }

    // Blend object colour values
    private void blendObjectColourValues()
    {
        // If the object is restored
        if (isObjectRestored)
        {
            // Blend the opacity of the object
            Color opaqueColor = new Color(0.0f, 0.0f, 0.0f, objectOpacity);
            objectRenderer.material.color = Color.Lerp(objectRenderer.material.color, opaqueColor, Time.deltaTime * colourBlendSpeed);

            // Blend the emissive colour of the object
            objectRenderer.material.SetColor("_EmissionColor", Color.Lerp(objectRenderer.material.GetColor("_EmissionColor"), restoredColour, Time.deltaTime * colourBlendSpeed));
        }
    }

    // Restore Object
    public void restoreObject()
    {
        // Set the object to be restored
        isObjectRestored = true;

        // Set the object opacity to 1
        objectOpacity = 1.0f;
    }

    // Disable object
    public void disableObject()
    {
        // Set the object opacity to 0
        objectOpacity = 0.0f;
    }
}
