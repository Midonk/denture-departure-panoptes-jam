using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/* Joue des sons les un après les autres dans l'ordre de la liste */

[RequireComponent(typeof(AudioSource))]
public class SoundTimeline : MonoBehaviour
{
    public TimelineSegment[] segments;
    private AudioSource source;

    private void Awake() {
        source = GetComponent<AudioSource>();
    }

    private void Start() {
        StartCoroutine(CheckPlay());
    }

    IEnumerator CheckPlay(){
        foreach (TimelineSegment el in segments)
        {
            source.clip = el.clip;
            source.Play();

            while(source.isPlaying){
                yield return new WaitForSeconds(1f);
            }

            el.evt?.Invoke();
        }

        GameManager.Instance.StratNewGameEffectively();
    }
}


[Serializable]
public class TimelineSegment
{
    public AudioClip clip;
    public UnityEvent evt;
}