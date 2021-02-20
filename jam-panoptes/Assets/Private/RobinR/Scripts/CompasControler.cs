using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompasControler : MonoBehaviour
{
    [Header("References")]
    public Transform Camera;
    public Vector2 TargetPosition;
    public RectTransform Compas;
    private Transform Player;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector2 cameraV2F = new Vector2(Camera.forward.x, Camera.forward.z);
        Vector2 cameraV2R = new Vector2(Camera.right.x, Camera.right.z);
        Vector2 characterPosV2 = new Vector2(Player.position.x, Player.position.z);
        Vector2 direction = TargetPosition - characterPosV2;
        float angle2 = Vector2.Angle(cameraV2R, direction.normalized);
        float angle1 = Vector2.Angle(cameraV2F, direction.normalized) * (angle2 < 90? -1: 1);



        Debug.Log(angle1);
        Compas.rotation = Quaternion.Euler(0.0f, 0.0f, angle1);
    }
}
