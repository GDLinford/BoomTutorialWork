using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScrollMovement : MonoBehaviour
{
    void Update()
    {
        //Sets the position to be the same, but adds more to the Z position
        // the mouse scroll delta, is the difference in the scrollwheel value
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + Input.mouseScrollDelta.y);
        
    }
}
