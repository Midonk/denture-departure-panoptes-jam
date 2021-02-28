using System.Collections;
using UnityEngine;

/* Joue des sons les un après les autres dans l'ordre de la liste */

[RequireComponent(typeof(AudioSource))]
public class SoundTimeline : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource source;

    private void Awake() {
        source = GetComponent<AudioSource>();
    }

    private void Start() {
        StartCoroutine(CheckPlay());
    }

    IEnumerator CheckPlay(){
        foreach (AudioClip clip in clips)
        {
            source.clip = clip;
            source.Play();

            while(source.isPlaying){
                yield return new WaitForSeconds(1f);
            }
        }

        GameManager.Instance.StratNewGameEffectively();
    }
}
