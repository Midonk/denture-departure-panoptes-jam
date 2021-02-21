using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTimer : Trigger
{
    public float time;
    private float Timer;

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if(Timer >= time)
        {
            Triggered();
        }
    }
}
