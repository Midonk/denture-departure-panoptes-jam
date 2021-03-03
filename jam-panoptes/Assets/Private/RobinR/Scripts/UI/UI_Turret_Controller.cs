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
    public RectTransform LightRectTransform;
    public Light LightObject;


    private void TurretController_OnBulletAmountChange(int next)
    {   
        Text_BulletAmount.text = string.Format("{0}/{1}", next, Turret.MaxBulletAmount);
    }


    private void TurretController_OnReloadTimerChange(float next)
    {
        float percent = Mathf.Clamp01(next / Turret.ReloadTime);
        Image_ReloadTimer.fillAmount = percent;

        if(next < Turret.ReloadTime)
        {
            Text_BulletAmount.text = "Rechargement";
            //LightRectTransform.localPosition = new Vector3(288*percent, 0.0f, 0.0f);
            LightObject.intensity = 1.0f * percent;
        }else
        {
            Text_BulletAmount.text = "64/64";
            //LightRectTransform.localPosition = new Vector3(288, 0.0f, 0.0f);
            LightObject.intensity = 1.0f;

        }
    }

    private void Awake(){
        Turret.OnBulletAmountChange += TurretController_OnBulletAmountChange;
        Turret.OnReloadChange += TurretController_OnReloadTimerChange;
        gameObject.SetActive(false);
    }

    private void Update(){}
}
