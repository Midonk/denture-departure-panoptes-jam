using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Parameters")]
    public float GameWonTime = 10.0f;

    [Header("Hiddens")]
    private TurretController[] Turrets;
    private int _AliveTurretsAmount;
    private float _GameWonTimer;

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

    public delegate void AliveTurretsAmountChangeHandler(int next);
    public event AliveTurretsAmountChangeHandler OnAliveTurretsAmountsChange;
    public delegate void WonTimerChangeHandler(float next);
    public event WonTimerChangeHandler OnWonTimerChange;
    
    private void TurretController_OnDeath(bool next)
    {
        AliveTurretsAmount += next ? -1 : 1;
        if(AliveTurretsAmount == 0)
        {
            GameOver(false);
        }
    }

    private void GameOver(bool won)
    {
        Debug.Log(won? "Gagné" : "Perdu");
        Time.timeScale = 0;
    }

    protected override void Awake()
    {
        base.Awake();
        
        GameObject[] turretObjects = GameObject.FindGameObjectsWithTag("Turret");
        Turrets = new TurretController[turretObjects.Length];

        for(int i = 0; i < Turrets.Length; i++)
        {
            Turrets[i] = turretObjects[i].GetComponent<TurretController>();
            Turrets[i].OnDeath += TurretController_OnDeath;
        }

        AliveTurretsAmount = Turrets.Length;
        GameWonTimer = 0;
    }

    private void Update()
    {
        if(GameWonTimer < GameWonTime)
        {
            GameWonTimer += Time.deltaTime;

            if(GameWonTimer >= GameWonTime)
            {
                GameOver(true);
            }
        }
    }
}
