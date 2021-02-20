using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCheese : TargetController
{
    public float CheeseAmount = 2.0f;
    protected override void Hit(TurretController target)
    {
        GameManager.Instance.AddCheese(CheeseAmount);
        Destroy(gameObject);
    }
}
