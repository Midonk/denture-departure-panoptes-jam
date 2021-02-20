
using UnityEngine;

public class MountTurret : MonoBehaviour
{
    private Transform turretSeat;
    private Vector3 outTurretPos;
    private Quaternion outTurretRot;
    private bool inTurret = false;
    public Transform player;
    private CharacterController cc;
    private CharMove charMove;

    private void Awake() {
        cc = GetComponent<CharacterController>();
        charMove = GetComponent<CharMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(InputManager.Instance.Shoot){
            if(inTurret){
                Debug.Log("dismount");
                cc.enabled = true;
                charMove.enabled = true;
                inTurret = false;
                transform.position = outTurretPos;
                player.rotation = outTurretRot;
            }

            else if(turretSeat){
                Debug.Log("mount");
                outTurretPos = transform.position;
                outTurretRot = transform.rotation;
                cc.enabled = false;
                charMove.enabled = false;
                //set la position du perso dans la tourelle
                transform.position = turretSeat.position;
                player.rotation = turretSeat.rotation;
                inTurret = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        GameObject turret = other.gameObject;
        if(turret.tag == "Turret"){
            Debug.Log("get seat");
            turretSeat = turret.GetComponent<TurretAccessor>().seat;
        }
    }
    
    private void OnTriggerExit(Collider other) {
        GameObject turret = other.gameObject;
        if(turret.tag == "Turret"){
            Debug.Log("no seat");
            turretSeat = null;
        }
    }
}
