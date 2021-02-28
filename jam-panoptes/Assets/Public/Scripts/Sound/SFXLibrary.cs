
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXLibrary : Singleton<SFXLibrary>
{
    private AudioSource source;
    public AudioClip warpSound;

    protected override void Awake() {
        base.Awake();
        source = GetComponent<AudioSource>();
    } 

    public void PlayWarpSFX(){
        source.PlayOneShot(warpSound);
    }
}
