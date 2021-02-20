using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [Header("Parameter")]
    public float SpawnRadius = 45.0f;
    public float SpawnTime = 2.0f;

    [Header("Reference")]
    public Transform TargetPoint;
    public TargetShip ShipPrefab;

    private float SpawnTimer;

    private void Update()
    {
        SpawnTimer += Time.deltaTime;

        if(SpawnTimer >= SpawnTime)
        {
            TargetShip ship = null;
            Vector2 SpawnDelta = Random.insideUnitCircle * SpawnRadius;
            Vector3 SpawnPos = transform.position + transform.right * SpawnDelta.x + transform.up * SpawnDelta.y;

            ship = Instantiate<TargetShip>(ShipPrefab, SpawnPos, Quaternion.identity);
            ship.TargetTurret = TargetPoint;
            ship.Spawner = transform;

            SpawnTimer -= SpawnTime;
        }
    }
}
