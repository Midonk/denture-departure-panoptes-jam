using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Transform respawnPoint;
    private GameObject other;

    private void OnTriggerEnter(Collider other)
    {
        this.other = other.gameObject; 
    }
    private void OnTriggerExit(Collider other)
    {
        this.other = null;
    }

    private void Update()
    {
        if(other)
        {
            other.transform.position = respawnPoint.position;
        }
    }
}
