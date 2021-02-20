using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBullet : TargetController
{
    public int DamageAmount = 2;
    protected override void Hit(TurretController target)
    {
        target.Damage(DamageAmount);
        Destroy(gameObject);
    }
}
