using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShip : TargetController
{
    [Header("Parameters")]
    public float ShootTime;
    
    [Range(0.0f, 1.0f)]
    public float CheeseSpawnRate = 0.8f;
    public float RandomCircleRadius;
    public Vector2 RoamingTimeRange;
    public float SpawnerDistance;

    [Header("References")]
    public TargetController BulletPrefab;
    public TargetController CheesePrefab;
    public Transform Cannon;
    public Transform Spawner{get;set;}
    public Transform TargetTurret{get;set;}

    [Header("Hidden")]
    private float RoamingTime;
    private float ShootTimer;
    private float RoamingTimer;
    private Vector3 Destination;
    private float TravelDistance;

    private void UpdateDestination()
    {
        Vector2 Offset = Random.insideUnitCircle * RandomCircleRadius;
        Destination = Spawner.position - (Spawner.forward * SpawnerDistance) + Spawner.right * Offset.x + Spawner.up * Offset.y;

        TravelDistance = (Destination - transform.position).magnitude;
    }
    protected override void Hit(TurretController target){}

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        UpdateDestination();
    }

    protected override void Update()
    {
        RoamingTimer += Time.deltaTime;
        ShootTimer += Time.deltaTime;

        if(RoamingTimer >= RoamingTime)
        {
            UpdateDestination();

            RoamingTimer -= RoamingTime;
            RoamingTime = Random.Range(RoamingTimeRange.x, RoamingTimeRange.y);
        }

        if(TravelDistance > 0)
        {
            Vector3 direction = (Destination - transform.position).normalized;

            transform.Translate(direction * Speed * Time.deltaTime, Space.World);
            TravelDistance -= Speed * Time.deltaTime;
        }

        transform.LookAt(TargetTurret);

        if(ShootTimer >= ShootTime)
        {
            TargetController target = null;

            if(Random.value < CheeseSpawnRate)
            {
                target = Instantiate<TargetController>(CheesePrefab, Cannon.position, Quaternion.identity);
            }else
            {
                target = Instantiate<TargetController>(BulletPrefab, Cannon.position, Quaternion.identity);
            }
            target.transform.LookAt(TargetTurret);
            ShootTimer -= ShootTime;
        }
    }
}
