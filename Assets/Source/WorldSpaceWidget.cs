using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldSpaceWidget : MonoBehaviour
{
    // Message for the widget text object to display
    [SerializeField]
    private string widgetMessage = "Placeholder";

    // Reference to the widget text object
    [SerializeField]
    private Text widgetTextObject;

    // Use this for initialization
    void Start()
    {
        // Set the text of the widget text object
        widgetTextObject.text = widgetMessage;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*--Editor Functions--*/

    // Draw a box gizmo
    public void OnDrawGizmos()
    {
        // Set the colour of the gizmo
        Gizmos.color = new Color(1, 0.0f, 1.0f, 0.5f);

        // Draw the box
        Gizmos.DrawCube(transform.position, transform.lossyScale);
    }
}
