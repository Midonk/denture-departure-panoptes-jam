using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPopUpCollision : TriggerCollision
{
    public Receiver[] OnTriggerExitReceivers;
    protected void OnTriggerExit(Collider other)
    {
        if(!IsTriggered || !UseOnce)
        {
            foreach(Receiver receiver in OnTriggerExitReceivers)
            {
                receiver.OutCome();
            }

            IsTriggered = true;
        }
    }
}
