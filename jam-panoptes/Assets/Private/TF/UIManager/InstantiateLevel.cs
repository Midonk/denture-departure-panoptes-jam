using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantiateLevel : MonoBehaviour
{
    public string sceneName;

    public void InstantiateScene(){
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
