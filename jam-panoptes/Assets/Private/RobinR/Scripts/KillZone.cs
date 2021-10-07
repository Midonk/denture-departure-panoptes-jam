using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Transform respawnPoint;
    //private GameObject other;

    private void OnCollisionEnter(Collision other)
    {
        //this.other = other.gameObject; 
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<CharMove>().ResetVelocity();
            other.gameObject.transform.position = respawnPoint.position;
            Debug.Log("boop");
        }
    }
    /* private void OnTriggerExit(Collider other)
    {
        this.other = null;
    }

    private void Update()
    {
        if(other)
        {
            other.transform.position = respawnPoint.position;
        }
    } */
}
