using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("Parameters")]

    [Range(1, 1000)]
    public int MaxHealth = 10;
    [Range(0.0f, 200.0f)]
    public float Sensitivity = 2.0f;
    [Range(0.0f, 2.0f)]
    public float ShootRate = 0.4f;
    [Range(0, 1000)]
    public int MaxBulletAmount = 64;
    [Range(0.0f, 10.0f)]
    public float ReloadTime = 4.0f;
    [Range(0.0f, 1000.0f)]
    public float MaxRange = 200.0f;
    public Vector2 VerticalRotationRange; 

    [Header("References")]
    public Camera MainCamera;
    public Transform Head;
    public Transform CannonPivot;

    [Header("Hiddens")]
    private bool ShootLeft; //alterne les tirs
    private bool _IsDead = false;
    private float CurrentHeadRotation;
    private float CurrentPivotRotation;
    private static int _Health;
    private float ShootTimer;
    private float _ReloadTimer;
    private int _BulletAmount;

    // #Exposure
    private int Health{
        get{return _Health;}
        set{
            _Health = value;
            OnHealthChange?.Invoke(_Health);
        }
    }

    private bool IsDead{
        get{return _IsDead;}
        set{
            if(_IsDead != value)
            {
                OnDeath?.Invoke(value);
            }
            _IsDead = value;
        }
    }

    private int BulletAmount{
        get{return _BulletAmount;}
        set{
            _BulletAmount = value;
            OnBulletAmountChange?.Invoke(_BulletAmount);
        }
    }

    private float ReloadTimer{
        get{return _ReloadTimer;}
        set{
            _ReloadTimer = value;
            OnReloadChange?.Invoke(_ReloadTimer);
        }
    }

    // #Events
    public delegate void BulletAmountChangeHandler(int amount);
    public event BulletAmountChangeHandler OnBulletAmountChange;

    public delegate void ReloadingHandler(float timePercentage);
    public event ReloadingHandler OnReloadChange;

    public delegate void HealthHandler(int next);
    public event HealthHandler OnHealthChange;

    public delegate void DeathHandler(bool isDead);
    public event DeathHandler OnDeath;

    public void Damage(int amount)
    {
        Health = Mathf.Clamp(Health - amount, 0, MaxHealth);

        if(Health > 0)
        {
            IsDead = false;
        }else
        {
            IsDead = true;
        }
    }

    private void This_OnDeath(bool next)
    {
        //gameObject.SetActive(!next);
    }

    // Start is called before the first frame update
    void Start()
    {
        BulletAmount = MaxBulletAmount;
        Health = MaxHealth;

        OnDeath += This_OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit)) {
                Transform objectHit = hit.transform;
                
                TargetRotation = Quaternion.LookRotation(objectHit.position - Head.position).eulerAngles;
                InitialPivotRotation = CannonPivot.rotation;
                InitialHeadRotation = Head.rotation;
                RotationProgress = 0.0f;
            }
        }

        if(RotationProgress < 1.0f)
        {
            if(RotationProgress <= 0.5f){
                RotationProgress += Time.deltaTime * AngularSpeed;
                CannonPivot.rotation = Quaternion.Lerp(InitialPivotRotation, Quaternion.Euler(InitialPivotRotation.eulerAngles.x, TargetRotation.y, 0.0f), RotationProgress * 2.0f);
                Head.rotation = Quaternion.Lerp(InitialHeadRotation, Quaternion.Euler(0.0f, TargetRotation.y, 0.0f), RotationProgress * 2.0f);

                if(RotationProgress > 0.5f)
                {
                    InitialPivotRotation = CannonPivot.rotation;
                }
            }else{
                RotationProgress += Time.deltaTime * AngularSpeed;
                CannonPivot.rotation = Quaternion.Lerp(InitialPivotRotation, Quaternion.Euler(TargetRotation.x, TargetRotation.y, 0.0f), RotationProgress - 0.5f);
            }
        }*/

        CurrentPivotRotation = Mathf.Clamp(CurrentPivotRotation + (InputManager.Instance.NormalizedMouseOffset.y * Sensitivity * Time.deltaTime), VerticalRotationRange.x, VerticalRotationRange.y);
        CurrentHeadRotation += -InputManager.Instance.NormalizedMouseOffset.x * Sensitivity * Time.deltaTime;

        Head.rotation = Quaternion.Euler(0.0f, CurrentHeadRotation, 0.0f);
        CannonPivot.rotation = Quaternion.Euler(CurrentPivotRotation, CurrentHeadRotation, 0.0f);


        if(BulletAmount > 0)
        {
            ShootTimer += Time.deltaTime;

            if(ShootTimer >= ShootRate && InputManager.Instance.Shoot)
            {
                Ray ray = new Ray(CannonPivot.position, CannonPivot.forward);

                foreach (RaycastHit item in Physics.RaycastAll(ray, MaxRange))
                {
                    if(item.transform.CompareTag("Target"))
                    {
                        item.transform.GetComponent<TargetController>().Damage(1);
                        break;
                    }
                }

                BulletAmount--;
                ShootTimer = 0;

                if(BulletAmount == 0)
                {
                    ReloadTimer = 0;
                }
            }
        }else
        {
            ReloadTimer += Time.deltaTime;

            if(ReloadTimer >= ReloadTime)
            {
                BulletAmount = MaxBulletAmount;
            }
        }
    }
}
