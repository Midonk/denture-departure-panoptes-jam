using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(AudioSource))]
public class ConditionalPlaySound : Singleton<ConditionalPlaySound>
{
    public AudioClip[] vaisseauHit;
    public AudioClip[] ennemiAbattu;
    public AudioClip[] vaisseauCritic;
    public AudioClip firstCheese;
    public AudioClip[] victoirVoice;
    public AudioClip victoirMusic;
    public AudioClip[] echecVoice;
    public AudioClip echecMusic;
    private AudioSource sourceMusic;
    private AudioSource sourceVoice;

    private void Awake() {
        sourceMusic = GetComponents<AudioSource>()[0];
        sourceVoice = GetComponents<AudioSource>()[1];
    }

    // Start is called before the first frame update
    void Start()
    {
        TurretController.OnHealthChange += PLayDamage;
    }

    public void PLayDamage(int health){
        bool critic = health <= TurretController.MaxHealth / 6; 
        if(critic){
            PlayAttackedCritic();
        }

        else{
            PlayAttacked();
        }
    }

    private void PlayAttacked(){
        AudioClip clip = vaisseauHit[Random.Range(0, vaisseauHit.Length - 1)];
        PlayVoice(clip);
    }
    
    private void PlayAttackedCritic(){
        AudioClip clip = vaisseauCritic[Random.Range(0, vaisseauCritic.Length - 1)];
        PlayVoice(clip);
    }

    public void PlayFirstCheese(){
        AudioClip clip = firstCheese;
        PlayVoice(clip);
    }

    public void PlayennemiAbattu(){
        AudioClip clip = ennemiAbattu[Random.Range(0, ennemiAbattu.Length - 1)];
        PlayVoice(clip);
    }

    public void PlayVictoire(){
        AudioClip clip = victoirVoice[Random.Range(0, ennemiAbattu.Length - 1)];
        PlayVoice(clip);
        PlayMusic(victoirMusic);
    }

    public void PlayEchec(){
        AudioClip clip = echecVoice[Random.Range(0, echecVoice.Length - 1)];
        PlayVoice(clip);
        PlayMusic(echecMusic);
    }

    private void PlayMusic(AudioClip clip){
        if(!sourceMusic.isPlaying){
            sourceMusic.loop = false;
            sourceMusic.clip = clip;
            sourceMusic.Play();
        }
    }
    
    private void PlayVoice(AudioClip clip){
        if(!sourceVoice.isPlaying){
            sourceVoice.clip = clip;
            sourceVoice.Play();
        }
    }
}
