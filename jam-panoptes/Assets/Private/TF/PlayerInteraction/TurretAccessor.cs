
using UnityEngine;

public class TurretAccessor : MonoBehaviour
{
    public Transform seat;

    public TurretController controller;

    private void Awake() {
        gameObject.tag = "Turret";
    }

    public void SetActiveController(bool next)
    {
        controller.Controllable = next;
    }
}
