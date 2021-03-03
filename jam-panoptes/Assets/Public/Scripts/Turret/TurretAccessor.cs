
using UnityEngine;
using UnityEngine.Audio;

public class TurretAccessor : MonoBehaviour
{
    public Transform seat;
    public TurretController controller;
    public Transform leftController;
    public Transform rightController;

    [Header("Audio")]
    public AudioClip turretReady;
    public AudioClip turretReload;
    private AudioSource source;

    private void Awake() {
        gameObject.tag = "Turret";
        source = GetComponent<AudioSource>();
        TurretController.OnReload += Reload;
    }

    public void SetActiveController(bool next)
    {
        controller.Controllable = next;
        if(next){
            source.clip = turretReady;
            source.Play();
        }
    }

    public void Reload(){
        source.clip = turretReload;
        source.Play();
    }
}
