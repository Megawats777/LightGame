using UnityEngine;
using System.Collections;

public class BoostCheckpoint : MonoBehaviour
{
    // Direction of the boost 
    public Vector3 boostDirection;

    // Boost velocity
    public float boostVelocity = 100.0f;

	// Use this for initialization
	void Start ()
    {
        // Set boost direction values
        setBoostDirectionValues();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // Set boost direction values
    private void setBoostDirectionValues()
    {

    }

    // Boost object
    public void boostObject(Rigidbody rb)
    {
        rb.AddForce(new Vector3(boostDirection.x * boostVelocity, boostDirection.y * boostVelocity, boostDirection.z * boostVelocity));
    }
}
