using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameOver_Controller : MonoBehaviour
{
    public void OnRestart(InstantiateLevel level)
    {
        level.InstantiateScene();
        GameManager.Instance.SetPause(false);
    }

    public void OnQuit(InstantiateLevel level)
    {
        level.InstantiateScene();
        GameManager.Instance.CancelGame();
        Reticle.UnlockCursor();
    }
}
