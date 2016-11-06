using UnityEngine;
using System.Collections;

public class RotatingObject : MonoBehaviour
{
    // The rotation speed
    [SerializeField]
    private float rotationSpeed = 50.0f;

    // Can rotate
    [HideInInspector]
    public bool canRotate = true;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If the object can rotate
        if (canRotate)
        {
            // Rotate the object
            transform.Rotate(new Vector3(1.0f * rotationSpeed * Time.deltaTime, 1.0f * rotationSpeed * Time.deltaTime, 1.0f * rotationSpeed * Time.deltaTime));
        }
	}
}
