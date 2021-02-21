using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause_Controller : MonoBehaviour
{    
    public void OnResume()
    {
        GameManager.Instance.SetPause(false);
    }

    public void OnQuit(InstantiateLevel level)
    {
        level.InstantiateScene();
        GameManager.Instance.SetPause(false);
        HUDManager.Instance.ShowPanel(0);
    }
}
