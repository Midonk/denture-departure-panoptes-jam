using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    public bool UseOnce;
    public Receiver[] receivers;

    protected bool IsTriggered;

    protected void Triggered()
    {
        if(!IsTriggered || !UseOnce)
        {
            foreach(Receiver receiver in receivers)
            {
                receiver.OutCome();
            }

            IsTriggered = true;
        }
    }
}
