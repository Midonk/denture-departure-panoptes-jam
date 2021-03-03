using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Transform respawnPoint;
    private void OnTriggerStay(Collider other)
    {
        other.transform.position = respawnPoint.position; 
    }
}
