using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private Vector2 _MovementDirection;
    private Vector2 _MouseOffset;

    public bool Interact{get;set;}
    public bool InteractUp{get;set;}
    public bool InteractDown{get;set;}
    public bool Shoot{get;set;}
    public bool ShootUp{get; set;}
    public bool ShootDown{get; set;}
    public bool Sprint{get;set;}
    public bool SprintUp{get;set;}
    public bool SprintDown{get;set;}

    public Vector2 NormalizedMovementDirection{
        get{return _MovementDirection.normalized;}
        set{_MovementDirection = value;}
    }
    
    public Vector2 RawMovementDirection{
        get{return _MovementDirection;}
    }

    public Vector2 MouseOffset{
        get{return _MouseOffset;}
        set{_MouseOffset = value;}
    }

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        _MovementDirection = new Vector2();
        if(Input.GetAxis("Horizontal") != 0)
        {
            _MovementDirection.x = Input.GetAxis("Horizontal");
        }

        if(Input.GetAxis("Vertical") != 0)
        {
            _MovementDirection.y = Input.GetAxis("Vertical");
        }

        Shoot = Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);
        ShootDown = Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);
        ShootUp = Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space);

        Sprint = Input.GetKey(KeyCode.LeftShift);
        SprintDown = Input.GetKeyDown(KeyCode.LeftShift);
        SprintUp = Input.GetKeyUp(KeyCode.LeftShift);

        Interact = Input.GetKey(KeyCode.E);
        InteractDown = Input.GetKeyDown(KeyCode.E);
        InteractUp = Input.GetKeyUp(KeyCode.E);

        _MouseOffset = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}
