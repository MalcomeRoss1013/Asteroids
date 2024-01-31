using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); //destroy the bullet

            
            //split off the children
            for (int x = 0; x < transform.childCount; x++)
            {
                Transform child = transform.GetChild(x);
                child.GetComponent<Collider>().enabled = true;
                child.GetComponent<Rigidbody>().isKinematic = false;
                child.transform.position = new Vector3(child.transform.position.x, child.transform.position.y, 0);
                child.GetComponent<AsteroidMovement>().FreeAsteroid();
                
            }
            transform.DetachChildren();
            
            //Let AsteroidManager know that you're being destroyed
            GetComponent<AsteroidManager>()?.onDestroyed();
            
            //destroy yourself
            Destroy(gameObject);
        }
    }
}
