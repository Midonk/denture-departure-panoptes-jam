
using UnityEngine;

public class TurretAccessor : MonoBehaviour
{
    public Transform seat;
    public TurretController controller;
    public Transform leftController;
    public Transform rightController;
    private AudioSource source;
    private void Awake() {
        gameObject.tag = "Turret";
        source = GetComponent<AudioSource>();
    }

    public void SetActiveController(bool next)
    {
        controller.Controllable = next;
        if(next){
            source.Play();
        }
    }
}
