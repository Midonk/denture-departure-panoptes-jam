using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetController : MonoBehaviour
{
    [Header("Parameters")]
    public float Speed = 10.0f;
    public int Health = 10;

    [Header("References")]
    public Transform MeshTransform;

    [Header("Hidden")]
    private bool HasHit;

    protected abstract void Hit(TurretController target);

    public virtual void Damage(int amount)
    {
        Health -= amount;

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Awake()
    {
        tag = "Target";
    }

    protected virtual void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Turret") && !HasHit)
        {
            Hit(other.gameObject.GetComponent<TurretController>());
            HasHit = true;
        }
    }
}
