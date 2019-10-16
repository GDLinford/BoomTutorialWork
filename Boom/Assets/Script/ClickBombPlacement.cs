using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBombPlacement : MonoBehaviour
{

    public GameObject bombPrefab;
  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //The Mouse Position in Pixels (for X and Y), but with a value of 10 offset in Z
            Vector3 mousePositionWithZOffset = Input.mousePosition;
            mousePositionWithZOffset.z = 10;

            //Where the camera is viewing from
            Vector3 cameraPosition = Camera.main.transform.position;

            //Get the position 10 unitys away from the mouse click down the camera frustrum
            Vector3 mousePositionInWorldSpace = Camera.main.ScreenToWorldPoint(mousePositionWithZOffset);


            // The Vector different from the camera, to the mouse click position down the frustrum
            //It effectively gets the direction of the mouse click through the camera frustrum
            Vector3 directionFromCameraToMouse = mousePositionInWorldSpace - cameraPosition;

            //This functions check for any Collider (trigger or normal) in the world, starting from camera position
            // and pointing towards the 'directionFromCameraToMouse' for an infinite distance away
            //This will return true, if we have hit anything.
            //
            //It has a special 'out' parameter, which will get populated with the information about what collider was in the way
            
            RaycastHit hitInfo;
            if (Physics.Raycast(new Ray(cameraPosition, directionFromCameraToMouse), out hitInfo, Mathf.Infinity))
            {
                // we have hit a collider, now the 'hitInfo' has been populated for us
                // create a bomb
                GameObject bombInstance = Instantiate(bombPrefab);
                //Parent it to whatever we hit
                bombInstance.transform.parent = hitInfo.collider.transform;

                // Set it's position to be the exact point we hit
                bombInstance.transform.position = hitInfo.point;

                //So we have an issue with scaling. And when the item has rotated.
                //Lets set our rotation to Zero
                //Quarternion.identity is 0,0,0 rotation.
                bombInstance.transform.localRotation = Quaternion.identity;

                //Set its local scale to one 
                bombInstance.transform.localScale = Vector3.one;

                // Get it's estimated true scale (based on all it's parent)
                // E.G. If the parents scale is 2, and our local scale is 1, Our true scale is 2
                Vector3 trueScale = bombInstance.transform.lossyScale;

                //Set our localscale to be one over true scale. This should make us look like we have a scale of 1
                //E.G. If the parents scale is 2, our scale is 1 over 2 or 0.5 to compensate for our parents scale
                bombInstance.transform.localScale = new Vector3(1 / trueScale.x, 1 / trueScale.y, 1 / trueScale.z);

                // Now light the fuse
                bombInstance.GetComponent<Bomb>().LightFuse();
            }
        }
    }
}
