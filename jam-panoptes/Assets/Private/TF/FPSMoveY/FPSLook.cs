using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform body;

    public bool LockY{get;set;} = false;

    private float xRotation = 0;

    // Start is called before the first frame update
    private void OnEnable() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void OnDisable() {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Vector3 currentRot = transform.localRotation.eulerAngles;
        currentRot.x = xRotation;
        if(LockY) currentRot.y = 0;
        transform.localRotation = Quaternion.Euler(currentRot);
    }
}
