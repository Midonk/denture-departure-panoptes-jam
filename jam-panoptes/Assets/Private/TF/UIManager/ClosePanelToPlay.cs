using UnityEngine.Events;
using UnityEngine;

public class ClosePanelToPlay : MonoBehaviour
{
    public Panel srcPanel;
    public UnityEvent defCloseCallback;

    public void DefClosePanel(){
        srcPanel.AnimationEnds += () => defCloseCallback.Invoke();
        srcPanel.ClosePanel();
    }
}
