
using UnityEngine;
using UnityEngine.Video;

public class AutoVideoLoader : MonoBehaviour
{
    public VideoPlayer player;
    public AudioSource audio;

    private void Awake() {
        
    }

    private void OnEnable() {
        player.Prepare();
        player.prepareCompleted += (VideoPlayer p) => p.Play();
        player.prepareCompleted += (VideoPlayer p) => p.Pause();
    }
    
    private void OnDisable() {
        player.Stop();
        audio.Play();
    }

    public void PlayVideo(){
        player.Play();
        audio.Pause();
    }
}
