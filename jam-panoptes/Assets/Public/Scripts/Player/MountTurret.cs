
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations.Rigging;

public class MountTurret : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public TriggerScripted TriggerScript;

    private TurretAccessor turretAccessor;
    private Vector3 outTurretPos;
    private Quaternion outTurretRot;
    private bool inTurret = false;
    public Transform player;
    private CharacterController cc;
    private CharMove charMove;
 /*    public AudioSource audioSource;
    public AudioClip mountTurretSound; */
    public Transform leftHand;
    public Transform rightHand;
    private Rig posture;

    private void Awake() {
        cc = GetComponent<CharacterController>();
        charMove = GetComponent<CharMove>();
        posture = GetComponentInChildren<Rig>();
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
                charMove.SetInTurret(false);
                posture.weight = 0;
            }

            else if(turretAccessor){
                Debug.Log("mount");
                
                TriggerScript.Trigger();
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
                charMove.SetInTurret(true);
                //audioSource.PlayOneShot(mountTurretSound);
                leftHand.position = turretAccessor.leftController.position;
                leftHand.rotation = turretAccessor.leftController.rotation;
                rightHand.position = turretAccessor.rightController.position;
                rightHand.rotation = turretAccessor.rightController.rotation;
                posture.weight = 1;
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
