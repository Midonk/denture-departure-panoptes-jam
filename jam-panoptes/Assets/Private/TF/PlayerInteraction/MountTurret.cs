
using UnityEngine;
using Cinemachine;

public class MountTurret : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    private TurretAccessor turretAccessor;
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
        if(InputManager.Instance.InteractDown){
            if(inTurret){
                Debug.Log("dismount");
                cc.enabled = true;
                charMove.enabled = true;
                inTurret = false;
                transform.position = outTurretPos;
                player.parent = transform;
                player.localPosition = Vector3.zero;
                player.rotation = outTurretRot;
                cinemachineVirtualCamera.Priority -= 10;
                turretAccessor.SetActiveController(false);
            }

            else if(turretAccessor){
                Debug.Log("mount");
                outTurretPos = transform.position;
                outTurretRot = transform.rotation;
                cc.enabled = false;
                charMove.enabled = false;
                //set la position du perso dans la tourelle
                transform.position = turretAccessor.seat.position;
                player.parent = turretAccessor.seat;
                player.rotation = turretAccessor.seat.rotation;
                inTurret = true;
                cinemachineVirtualCamera.Priority += 10;
                turretAccessor.SetActiveController(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        GameObject turret = other.gameObject;
        if(turret.tag == "Turret"){
            Debug.Log("get seat");
            turretAccessor = turret.GetComponent<TurretAccessor>();
        }
    }
    
    private void OnTriggerExit(Collider other) {
        GameObject turret = other.gameObject;
        if(turret.tag == "Turret"){
            Debug.Log("no seat");
            turretAccessor = null;
        }
    }
}
