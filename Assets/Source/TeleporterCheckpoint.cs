using UnityEngine;
using System.Collections;

public class TeleporterCheckpoint : MonoBehaviour
{
    // Reference to the teleporter nav point
    public TeleporterNavPoint navPoint;

    // Called before start
    public void Awake()
    {
        
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // When an object overlaps this object
    public void OnTriggerEnter(Collider other)
    {
        // If the overlaping object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Reference to the player
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            // If a nav point has been set
            if (navPoint)
            {
                // Teleport the player
                player.gameObject.transform.position = navPoint.getNavPointLocation();
            }
            else
            {
                Debug.Log("No nav point has been set for " + gameObject.name);
            }
        }
    }
}
