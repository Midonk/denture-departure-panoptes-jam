using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnyButton : Trigger
{
    private void Update()
    {
        if(Input.anyKeyDown)
        {
            Triggered();
        }
    }
}
