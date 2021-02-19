using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : Singleton<HUDManager>
{
    [Header("References")]
    public GameObject[] panels;
    
    protected override void Awake()
    {
        base.Awake();
    }
}
