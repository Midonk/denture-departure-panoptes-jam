using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : Singleton<HUDManager>
{
    [Header("References")]
    public GameObject[] panels;
    
    public void ShowPanel(int index)
    {
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == index);
        }
    }
    protected override void Awake()
    {
        Instance = this;
    }
}
