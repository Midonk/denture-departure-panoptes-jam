using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [Header("Parameter")]
    public float SpawnRadius = 45.0f;
    public float SpawnTime = 2.0f;
    [Range(0.0f, 1.0f)]
    public float CheeseSpawnRate = 0.8f;

    [Header("Reference")]
    public Transform TargetPoint;
    public TargetController CheesePrefab;
    public TargetController BulletPrefab;

    private float SpawnTimer;

    private void Update()
    {
        SpawnTimer += Time.deltaTime;

        if(SpawnTimer >= SpawnTime)
        {
            TargetController target = null;
            Vector2 SpawnDelta = Random.insideUnitCircle * SpawnRadius;
            Vector3 SpawnPos = transform.position + transform.right * SpawnDelta.x + transform.up * SpawnDelta.y;

            if(Random.value < CheeseSpawnRate)
            {
                target = Instantiate<TargetController>(CheesePrefab, SpawnPos, Quaternion.identity);
            }else
            {
                target = Instantiate<TargetController>(BulletPrefab, SpawnPos, Quaternion.identity);
            }

            target.transform.LookAt(TargetPoint);

            SpawnTimer -= SpawnTime;
        }
    }
}
