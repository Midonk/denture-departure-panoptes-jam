using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Parameters")]
    public float GameWonTime = 10.0f;
    public float MaxCheeseAmount = 10.0f;

    [Header("Hiddens")]
    private TurretController[] Turrets;
    private int _AliveTurretsAmount;
    private float _GameWonTimer;
    private float _CheeseAmount;

    private int AliveTurretsAmount{
        get{return _AliveTurretsAmount;}
        set{
            _AliveTurretsAmount = value;
            OnAliveTurretsAmountsChange?.Invoke(_AliveTurretsAmount);
        }
    }
    private float GameWonTimer{
        get{return _GameWonTimer;}
        set{
            _GameWonTimer = value;
            OnWonTimerChange?.Invoke(_GameWonTimer);
        }
    }
    private float CheeseAmount{
        get{return _CheeseAmount;}
        set{
            _CheeseAmount = value;
            OnCheeseAmountChange?.Invoke(_CheeseAmount);
        }
    }

    public delegate void AliveTurretsAmountChangeHandler(int next);
    public event AliveTurretsAmountChangeHandler OnAliveTurretsAmountsChange;
    public delegate void WonTimerChangeHandler(float next);
    public event WonTimerChangeHandler OnWonTimerChange;
    public delegate void CheeseAmountChangeHandler(float next);
    public event CheeseAmountChangeHandler OnCheeseAmountChange;
    
    private void TurretController_OnDeath(bool next)
    {
        GameOver(false);
    }

    public void AddCheese(float amount)
    {
        CheeseAmount = Mathf.Clamp(CheeseAmount + amount, 0, MaxCheeseAmount);
    }
    private void GameOver(bool won)
    {
        Debug.Log(won? "Gagné" : "Perdu");
        Time.timeScale = 0;
    }

    protected override void Awake()
    {
        base.Awake();
        Cursor.lockState = CursorLockMode.None;
        CheeseAmount = 5.0f;
        
        GameObject[] turretObjects = GameObject.FindGameObjectsWithTag("Player");
        Turrets = new TurretController[turretObjects.Length];

        for(int i = 0; i < Turrets.Length; i++)
        {
            Turrets[i] = turretObjects[i].GetComponent<TurretController>();
            Debug.Log(Turrets[i].name);
            Turrets[i].OnDeath += TurretController_OnDeath;
        }

        AliveTurretsAmount = Turrets.Length;
        GameWonTimer = 0;
    }

    private void Update()
    {
        if(GameWonTimer < GameWonTime && CheeseAmount == 0)
        {
            GameWonTimer += Time.deltaTime;

            if(GameWonTimer >= GameWonTime)
            {
                GameOver(true);
            }
        }else if(CheeseAmount > 0)
        {
            AddCheese(- Time.deltaTime);
        }
    }
}
