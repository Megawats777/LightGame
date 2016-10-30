using UnityEngine;
using System.Collections;

public class BoostCheckpoint : MonoBehaviour
{
    // Boost velocity
    public float boostVelocity = 50.0f;

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
    public void boostObject(PlayerController player)
    {
        player.normalMovementSpeed += boostVelocity;
    }
}
