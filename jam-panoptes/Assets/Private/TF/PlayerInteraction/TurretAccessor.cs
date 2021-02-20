
using UnityEngine;

public class TurretAccessor : MonoBehaviour
{
    public Transform seat;

    private void Awake() {
        gameObject.tag = "Turret";
    }
}
