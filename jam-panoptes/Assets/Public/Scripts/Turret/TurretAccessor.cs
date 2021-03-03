
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
    }

    public void SetActiveController(bool next)
    {
        controller.Controllable = next;
        if(next){
            TurretController.OnReload += Reload;
            source.clip = turretReady;
            source.Play();
        }

        else
        {
            TurretController.OnReload -= Reload;
        }
    }

    public void Reload(){
        source.clip = turretReload;
        source.Play();
    }
}
