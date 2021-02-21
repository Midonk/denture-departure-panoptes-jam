using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollision : Trigger
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Triggered();
        }
    }
}
