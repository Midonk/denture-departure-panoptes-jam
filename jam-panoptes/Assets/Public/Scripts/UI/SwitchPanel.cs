
using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    public Panel destPanel;
    public Panel srcPanel;

    public void SwitchToPanel(){
        srcPanel.AnimationEnds += () => destPanel.OpenPanel();
        srcPanel.ClosePanel();
    }
}
