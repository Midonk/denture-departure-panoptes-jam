using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverHideTutorial : Receiver
{
    public UI_Game_Controller GameController;
    public override void OutCome()
    {
        GameController.HideTutorial();
    }
}
