using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;


    private void OnTriggerEnter(Collider other)
    {
        //open door
        Door1.SetActive(false);
        Door2.SetActive(false);
        
        //instantiate some targets to fire at
    }

    private void OnTriggerExit(Collider other)
    {
        //close the doors

    }
}
