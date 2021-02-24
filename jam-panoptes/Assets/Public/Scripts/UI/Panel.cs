
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class Panel : MonoBehaviour
{
    public AnimationClip openPanel;
    public AnimationClip closePanel;

    public delegate void AnimFallback();
    public event AnimFallback AnimationStarts;
    public event AnimFallback AnimationEnds;


    private Animation animController;

    private void Awake() {
        animController = GetComponent<Animation>();
        if(openPanel){
            animController.AddClip(openPanel, openPanel.name);
        }

        if(closePanel){
            animController.AddClip(closePanel, closePanel.name);
        }

        gameObject.SetActive(false);
    }

    public void OpenPanel(){
        if(openPanel){
            animController.Play(openPanel.name);
        }

        else{
            AnimStarted();
            AnimEnded();
        }

        gameObject.SetActive(true);
    }
    
    public void ClosePanel(){
        AnimationEnds += () => gameObject.SetActive(false);

        if(closePanel){
            animController.Play(closePanel.name);
        }

        else{
            AnimStarted();
            AnimEnded();
        }
    }

    //triggered by animation
    public void AnimStarted(){
        AnimationStarts?.Invoke();
        AnimationStarts = null;
    }
    
    //triggered by animation
    public void AnimEnded(){
        AnimationEnds?.Invoke();
        AnimationEnds = null;
    }
}
