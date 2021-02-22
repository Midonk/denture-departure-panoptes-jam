using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverChangeScene : Receiver
{
    public InstantiateLevel level;
    public override void OutCome()
    {
        level.InstantiateScene();
    }
}
