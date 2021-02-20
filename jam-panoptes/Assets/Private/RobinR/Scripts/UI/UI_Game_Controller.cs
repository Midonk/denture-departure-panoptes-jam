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

    private void GameManager_OnTimerChange(float next)
    {
        Image_TimerBar.fillAmount = next / Game.GameWonTime;
    }

    private void GameManager_OnCheeseAmountChange(float next)
    {
        Image_CheeseBar.fillAmount = next / Game.MaxCheeseAmount;
    }

    private void Start(){
        
        Image_CheeseBar.fillAmount = 0.0f;
        Image_TimerBar.fillAmount = 0.0f;

        Game = GameManager.Instance;
        Game.OnWonTimerChange += GameManager_OnTimerChange;
        Game.OnCheeseAmountChange += GameManager_OnCheeseAmountChange;
    }
}
