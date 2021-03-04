using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Game_Controller : MonoBehaviour
{
    [Header("References")]
    public GameManager Game;
    public Image Image_TimerBar;
    public Image Image_HealthBar;
    public Image Image_CheeseBar;

    public Text Text_Tutorial;
    public GameObject Object_Text_Tip;
    public string[] Tutorials;

    private float ShowTime;
    private float ShowTimer;

    private void GameManager_OnTimerChange(float next)
    {
        Image_TimerBar.fillAmount = next / Game.GameWonTime;
    }

    private void GameManager_OnCheeseAmountChange(float next)
    {
        Image_CheeseBar.fillAmount = next / Game.MaxCheeseAmount;
    }

    private void GameManager_OnHealthAmountChange(int next, int max)
    {
        Image_HealthBar.fillAmount = next * 1.0f / max;
    }

    public void ShowTutorial(int index, float showTime)
    {
        if(index != 4)
        {
            Text_Tutorial.transform.parent.gameObject.SetActive(true);
            Text_Tutorial.text = Tutorials[index];
        }else
        {
            Object_Text_Tip.gameObject.SetActive(true);
        }

        ShowTime = showTime;
        ShowTimer = 0; 
    }

    public void HideTutorial()
    {
        Text_Tutorial.transform.parent.gameObject.SetActive(false);
        Text_Tutorial.text = "";
        Object_Text_Tip.gameObject.SetActive(false);
    }

    private void Start(){
        
        Image_CheeseBar.fillAmount = 0.0f;
        Image_TimerBar.fillAmount = 0.0f;

        Game = GameManager.Instance;
        Game.OnWonTimerChange += GameManager_OnTimerChange;
        Game.OnCheeseAmountChange += GameManager_OnCheeseAmountChange;
        Game.OnHealthAmountChange += GameManager_OnHealthAmountChange;
    }

    private void Update()
    {
        if(ShowTime > 0)
        {
            ShowTimer += Time.deltaTime;

            if(ShowTimer >= ShowTime)
            {
                HideTutorial();
            }
        }
    }
}
