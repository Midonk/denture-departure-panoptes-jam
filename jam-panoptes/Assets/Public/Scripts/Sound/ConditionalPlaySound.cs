
using UnityEngine;

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
    [Range(0, 1)]
    public float randomness;
    public AudioSource sourceMusic;
    public AudioSource sourceVoice;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnHealthAmountChange += PlayDamage;
    }

    public void PlayDamage(int health, int max){
        bool critic = health <= max / 3; 
        if(critic){
            PlayAttackedCritic();
        }

        else{
            PlayAttacked();
        }
    }

    private void PlayAttacked(){
        AudioClip clip = vaisseauHit[Random.Range(0, vaisseauHit.Length)];
        PlayVoice(clip, randomness);
    }
    
    private void PlayAttackedCritic(){
        AudioClip clip = vaisseauCritic[Random.Range(0, vaisseauCritic.Length)];
        PlayVoice(clip, randomness);
    }

    public void PlayFirstCheese(){
        AudioClip clip = firstCheese;
        PlayVoice(clip, 1);
    }

    public void PlayennemiAbattu(){
        AudioClip clip = ennemiAbattu[Random.Range(0, ennemiAbattu.Length)];
        PlayVoice(clip, randomness);
    }

    public void PlayVictoire(){
        AudioClip clip = victoirVoice[Random.Range(0, victoirVoice.Length)];
        PlayVoice(clip, 1, true);
        PlayMusic(victoirMusic);
    }

    public void PlayEchec(){
        AudioClip clip = echecVoice[Random.Range(0, echecVoice.Length)];
        PlayVoice(clip, 1, true);
        PlayMusic(echecMusic);
    }

    private void PlayMusic(AudioClip clip){
        sourceMusic.loop = false;
        sourceMusic.clip = clip;
        sourceMusic.Play();
    }
    
    private void PlayVoice(AudioClip clip, float randomMax, bool force = false){
        float rng = Random.Range(0f, 1f);

        if((!sourceVoice.isPlaying && rng <= randomMax) || force){
            sourceVoice.clip = clip;
            sourceVoice.Play();
        }
    }
}
