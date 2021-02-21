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
    public AudioClip victoir;
    public AudioClip echec;
    private AudioSource sourceMusic;
    private AudioSource sourceVoice;

    private void Awake() {
        sourceMusic = GetComponents<AudioSource>()[0];
        sourceVoice = GetComponents<AudioSource>()[1];
    }

    // Start is called before the first frame update
    void Start()
    {
        //TurretController.OnHealthChange += 
        //vaisseau se fait attaquer + état critique
        //test hit fromage => GameManager addCheese()
        //vaisseau enemi abattu => targetShip
        //victoire => GameManager gameOver()
        //défaite => GameManager gameOver()
    }

    public void PlayAttacked(){
        AudioClip clip = vaisseauHit[Random.Range(0, vaisseauHit.Length - 1)];
        PlayVoice(clip);
    }
    
    public void PlayAttackedCritic(){
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
        AudioClip clip = victoir;
        PlayMusic(clip);
    }

    public void PlayEchec(){
        AudioClip clip = echec;
        PlayMusic(clip);
    }

    private void PlayMusic(AudioClip clip){
        if(!sourceMusic.isPlaying){
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
