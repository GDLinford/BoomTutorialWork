using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float explosionForce = 10;
    public float explosionRadius = 5;
    public float fuseCountdown = 3;

    //Make it private so you have to call a function
    private bool litFuse = false;
  
    void Update()
    {
        if (litFuse)
        {
            //Time.deltaTime is the difference in seconds between each frame
            //so this will countdown in seconds from its initial value 3
            fuseCountdown -= Time.deltaTime;

            if (fuseCountdown <= 0)
            {
                SelfDestruct();
            }
        }
        
    }

    public void LightFuse()
    {
        litFuse = true;
    }

    private void SelfDestruct()
    {

        //This grabs all colliders in a sphere radius around the bomb (which we will explode)
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            //For each item, try to get a rigidbody so we can explode it
            Rigidbody r = collider.GetComponent<Rigidbody>();
            if (r != null)
            {
                //if it has a rigidbody
                //Adds an explosive force, from the bomb position to the rigidbody
                //we used the impulse force, as it's much more powerful
                r.AddExplosionForce(explosionForce, transform.position, explosionRadius, 0, ForceMode.Impulse);
            }
        }

        // And now we are done with affecting the other colliders, its time to die >;)
        Destroy(gameObject); //kills self
    }
}
