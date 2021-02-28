
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public Panel firstPanel;

    // Start is called before the first frame update
    void Start()
    {
        firstPanel.OpenPanel();
    }

    public void QuitGame(){
        Application.Quit();
    }
}
