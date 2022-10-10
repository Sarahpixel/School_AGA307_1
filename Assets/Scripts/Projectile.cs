using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroy our projectile after 5 sec
        Destroy(this.gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //check to see if the collided objecthas the tag "TARGET"
        if (collision.collider.CompareTag("Target"))
        {
            //changes the color of the collider
            collision.collider.GetComponent<Renderer>().material.color = Color.red;
            //destroys the gameobject after 1 sec
            Destroy(collision.collider.gameObject, 1f);
            //destroy this gameobject
            Destroy(this.gameObject);
        } 

    }

   
  
}
