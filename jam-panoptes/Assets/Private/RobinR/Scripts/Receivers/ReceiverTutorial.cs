using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverTutorial : Receiver
{
    public UI_Game_Controller GameController;
    public int TutorialIndex;
    public float TutorialShowTime;
    public override void OutCome()
    {
        GameController.ShowTutorial(TutorialIndex, TutorialShowTime);
    }
}
