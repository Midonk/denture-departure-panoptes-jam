using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Turret_Controller : MonoBehaviour
{
    [Header("References")]
    public TurretController Turret;
    public Text Text_BulletAmount;
    public Image Image_ReloadTimer;
    public Image Image_HealthBar;


    private void TurretController_OnBulletAmountChange(int next)
    {   
        Text_BulletAmount.text = string.Format("{0}/{1}", next, Turret.MaxBulletAmount);
    }

    private void TurretController_OnHealthChange(int next)
    {
        Image_HealthBar.fillAmount = Mathf.Clamp01(next * 1.0f / Turret.MaxHealth);
    }

    private void TurretController_OnReloadTimerChange(float next)
    {
        Image_ReloadTimer.fillAmount = Mathf.Clamp01(next / Turret.ReloadTime);
        if(next < Turret.ReloadTime)
        {
            Text_BulletAmount.gameObject.SetActive(false);
        }else
        {
            Text_BulletAmount.gameObject.SetActive(true);
        }
    }

    private void Awake(){
        Turret.OnBulletAmountChange += TurretController_OnBulletAmountChange;
        Turret.OnHealthChange += TurretController_OnHealthChange;
        Turret.OnReloadChange += TurretController_OnReloadTimerChange;
    }

    private void Update(){}
}
