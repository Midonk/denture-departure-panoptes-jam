using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TurretController : MonoBehaviour
{
    [Header("Parameters")]

    [Range(1, 1000)]
    public static int MaxHealth = 200;
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
    public float VFXDuraction = 0.1f;

    [Header("References")]
    public Camera MainCamera;
    public Transform Head;
    public Transform CannonPivot;
    public GameObject HUD;
    public Animator animator;
    public Transform LeftMouth;
    public Transform RightMouth;
    public Transform LeftEffect;
    public Transform RightEffect;
    public AudioSource asource;
    public AudioClip pan;

    [Header("Hiddens")]
    private bool ShootLeft; //alterne les tirs
    private bool _IsDead = false;
    private float CurrentHeadRotation;
    private float CurrentPivotRotation;
    private static int _Health;
    private float ShootTimer;
    private float _ReloadTimer;
    private int _BulletAmount;
    private float VFXDurationTimer;
    

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

    public bool Controllable{get;set;}

    // #Events
    public delegate void BulletAmountChangeHandler(int amount);
    public event BulletAmountChangeHandler OnBulletAmountChange;

    public delegate void ReloadingHandler(float timePercentage);
    public event ReloadingHandler OnReloadChange;

    public delegate void HealthHandler(int next);
    public static event HealthHandler OnHealthChange;

    public delegate void DeathHandler(bool isDead);
    public event DeathHandler OnDeath;

    public void Damage(int amount)
    {
        Health = Mathf.Clamp(Health - amount, 0, MaxHealth);
        Debug.Log(Health);

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
        _Health = MaxHealth;

        OnDeath += This_OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        VFXDurationTimer += Time.deltaTime;

        if(VFXDurationTimer > VFXDuraction)
        {
            RightEffect.gameObject.SetActive(false);
            LeftEffect.gameObject.SetActive(false);
        }
        if(Controllable)
        {
            CurrentPivotRotation = Mathf.Clamp(CurrentPivotRotation + (-InputManager.Instance.MouseOffset.y * Sensitivity * Time.deltaTime), VerticalRotationRange.x, VerticalRotationRange.y);
            CurrentHeadRotation += InputManager.Instance.MouseOffset.x * Sensitivity * Time.deltaTime;

            Head.rotation = Quaternion.Euler(0.0f, CurrentHeadRotation, 0.0f);
            CannonPivot.rotation = Quaternion.Euler(0.0f, CurrentHeadRotation, CurrentPivotRotation);


            if(BulletAmount > 0)
            {
                ShootTimer += Time.deltaTime;

                if(ShootTimer >= ShootRate && InputManager.Instance.Shoot)
                {
                    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

                    foreach (RaycastHit item in Physics.RaycastAll(ray, MaxRange))
                    {
                        if(item.transform.CompareTag("Target"))
                        {
                            item.transform.GetComponent<TargetController>().Damage(1);
                            break;
                        }
                    }

                    float targetSpeed = 1/3 / ShootRate;

                    if(animator.speed != targetSpeed && targetSpeed > 1)
                    {
                        animator.speed = targetSpeed;
                    }else if(animator.speed != 1)
                    {
                        animator.speed = 1;
                    }


                    if(ShootLeft)
                    {
                        animator.Play("ShootLeft");
                        LeftEffect.gameObject.SetActive(true);
                        RightEffect.gameObject.SetActive(false);
                        LeftMouth.Rotate(new Vector3(0.0f, 0.0f, -180f/32f), Space.Self);
                    }else
                    {
                        animator.Play("ShootRight");
                        RightEffect.gameObject.SetActive(true);
                        LeftEffect.gameObject.SetActive(false);
                        RightMouth.Rotate(0.0f, 0.0f, -180.0f/32.0f, Space.Self);

                    }

                    asource.PlayOneShot(pan);
                    VFXDurationTimer = 0;
                    ShootLeft = !ShootLeft;


                    BulletAmount--;
                    ShootTimer = 0;

                    if(BulletAmount == 0)
                    {
                        if(animator.speed != 1)
                        {
                            animator.speed = 1;
                        }

                        ReloadTimer = 0;
                    }
                }
            }else
            {
                ReloadTimer += Time.deltaTime;

                LeftMouth.Rotate(new Vector3(0.0f, 0.0f, 180f / ReloadTime * Time.deltaTime), Space.Self);
                RightMouth.Rotate(new Vector3(0.0f, 0.0f, 180f / ReloadTime * Time.deltaTime), Space.Self);

                if(ReloadTimer >= ReloadTime)
                {
                    BulletAmount = MaxBulletAmount;
                    LeftMouth.localRotation =  Quaternion.Euler (new Vector3(0, 0, 90));
                    RightMouth.localRotation =  Quaternion.Euler (new Vector3(0, 0, 90));
                }
            }

            if(!HUD.activeInHierarchy)
            {
                HUD.SetActive(true);
            }
        }else
        {
            if(HUD.activeInHierarchy)
            {
                HUD.SetActive(false);
                
                 Head.rotation = Quaternion.Euler(Vector3.zero);
                CannonPivot.rotation = Quaternion.Euler(Vector3.zero);
            }
        }
    }
}
