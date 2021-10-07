
using UnityEngine;

public class CharMove : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    private CharacterController cc;
    private Vector3 velocity = new Vector3();
    private Vector2 input;
    private Transform cam; 
    public Transform player;
    private Animator animator;

    private void Awake() {
        cc = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        animator = GetComponentInChildren<Animator>();
    }

    public void ResetVelocity(){
        velocity = Vector3.zero;
        transform.position = new Vector3(-1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MoveChar();
    }

    private void MoveChar(){
        float dt = Time.deltaTime;
        velocity = cc.isGrounded ? new Vector3(0, 0, 0) : new Vector3(0, velocity.y, 0);
        velocity += Physics.gravity * dt;

        input = InputManager.Instance.RawMovementDirection;

        velocity += input.y * cam.forward * dt * moveSpeed;
        velocity += input.x * cam.right * dt * moveSpeed;

        cc.Move(velocity);
        bool pressInput = input.magnitude != 0;
        animator.SetBool("isRunning", pressInput);

        if(pressInput){
            player.rotation = Quaternion.RotateTowards(player.rotation, Quaternion.Euler(new Vector3(0 , Vector3.SignedAngle(transform.forward, cc.velocity, Vector3.up), 0)), rotateSpeed * Time.deltaTime);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos() {
        if(cc)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + cc.velocity);
        }
    }
#endif

    public void SetInTurret()
    {
        animator.SetTrigger("inTurret");
    }
    
    public void SetOutTurret()
    {
        animator.SetTrigger("outTurret");
    }
}
