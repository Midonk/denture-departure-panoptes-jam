using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private Vector2 _MovementDirection;
    private Vector2 _MouseOffset;
    private Vector2 LastMousePos;
    private Vector2 CurrentMousePos;
    public bool Shoot{get;set;}
    public bool Sprint{get;set;}

    public Vector2 NormalizedMovementDirection{
        get{return _MovementDirection.normalized;}
        set{_MovementDirection = value;}
    }

    public Vector2 NormalizedMouseOffset{
        get{return _MouseOffset.normalized;}
        set{_MouseOffset = value;}
    }

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        CurrentMousePos = Input.mousePosition;

        if(Input.GetAxis("Horizontal") != 0)
        {
            _MovementDirection.x = Input.GetAxis("Horizontal");
        }

        if(Input.GetAxis("Vertical") != 0)
        {
            _MovementDirection.y = Input.GetAxis("Vertical");
        }

        Shoot = Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);
        Sprint = Input.GetKey(KeyCode.LeftShift);

        _MouseOffset = LastMousePos - CurrentMousePos;

        LastMousePos = CurrentMousePos;
    }
}
