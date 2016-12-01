using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TeleporterNavPoint : MonoBehaviour
{
    // The nav point's location
    private Vector3 navPointLocation;

    // Called before start
    public void Awake()
    {
        // Set the nav point's location
        setNavPointLocation();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set the nav point's location
    private void setNavPointLocation()
    {
        navPointLocation = transform.position;
    }

    // Get the nav point's location
    public Vector3 getNavPointLocation()
    {
        return navPointLocation;
    }


    /*--Editor Functions--*/

    // Draw a wire sphere gizmo
    public void OnDrawGizmos()
    {
        // Set the colour of the gizmo
        Gizmos.color = Color.magenta;

        // Draw the gizmo
        Gizmos.DrawWireSphere(transform.position, 1.0f);
    }
}
