using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Game_Controller : MonoBehaviour
{
    [Header("References")]
    public GameManager Game;
    public Image Image_TimerBar;
    public Image Image_CheeseBar;

    public Text Text_Tutorial;
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

    public void ShowTutorial(int index, float showTime)
    {
        Text_Tutorial.text = Tutorials[index];

        ShowTime = showTime;
        ShowTimer = 0;
    }

    public void HideTutorial()
    {
        Text_Tutorial.text = "";
    }

    private void Start(){
        
        Image_CheeseBar.fillAmount = 0.0f;
        Image_TimerBar.fillAmount = 0.0f;

        Game = GameManager.Instance;
        Game.OnWonTimerChange += GameManager_OnTimerChange;
        Game.OnCheeseAmountChange += GameManager_OnCheeseAmountChange;
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
