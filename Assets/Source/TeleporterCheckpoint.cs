using UnityEngine;
using System.Collections;

public class TeleporterCheckpoint : MonoBehaviour
{
    // Reference to the teleporter nav point
    private TeleporterNavPoint navPoint;

    // Called before start
    public void Awake()
    {
        // Get the teleporter navpoint
        navPoint = GetComponentInChildren<TeleporterNavPoint>();
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

            // Teleport the player
            player.gameObject.transform.position = navPoint.getNavPointLocation();
        }
    }
}
