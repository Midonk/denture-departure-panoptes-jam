using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverChangeScene : Receiver
{
    InstantiateLevel level;
    public override void OutCome()
    {
        level.InstantiateScene();
    }
}
