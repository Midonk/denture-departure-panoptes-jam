
using UnityEngine;
using UnityEngine.Video;

public class AutoVideoLoader : MonoBehaviour
{
    public VideoPlayer player;

    private void OnEnable() {
        player.Play();
    }
    
    private void OnDisable() {
        player.Stop();
    }
}
