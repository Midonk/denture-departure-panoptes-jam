
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Diagnostics;

public class InitAudioMixerSetup : MonoBehaviour
{
    public AudioMixer mixer;
    public string[] propertiesName;

    public AudioSource sfxPlayer;
    public AudioClip selectClip;
    public AudioClip acceptClip;
    public AudioClip gameStartClip;

    private void Start() {
        foreach (string propertyName in propertiesName)
        {
            mixer.SetFloat(propertyName, Mathf.Log10(PlayerPrefs.GetFloat(propertyName, 1)) * 20);
        }

        sfxPlayer.volume = 1;

        /*        
        Selectable[] uis = Selectable.allSelectablesArray;
        Debug.Log(uis.Length);
        EventTrigger.Entry selectedTrigger = new EventTrigger.Entry();
        selectedTrigger.eventID = EventTriggerType.Select;
        selectedTrigger.callback.AddListener(new UnityAction<BaseEventData>(PlaySelected));

        EventTrigger.Entry pointerEnterTrigger = new EventTrigger.Entry();
        pointerEnterTrigger.eventID = EventTriggerType.Select;
        pointerEnterTrigger.callback.AddListener(new UnityAction<BaseEventData>(PlaySelected));

        foreach (Selectable ui in uis)
        {
            EventTrigger evt = ui.gameObject.AddComponent<EventTrigger>();
            evt.triggers.Add(selectedTrigger);
            evt.triggers.Add(pointerEnterTrigger);

            Button btn = ui.GetComponent<Button>();
            if(btn){
                btn.onClick.AddListener(() => PlayAcepted());
            }
        }
        */
    }

    public void PlaySelected(){
        sfxPlayer.PlayOneShot(selectClip);
    }
    
    public void PlayAcepted(){
        sfxPlayer.PlayOneShot(acceptClip);
    }
    
    public void PlayStartGame(){
        sfxPlayer.PlayOneShot(gameStartClip);
    }
}
