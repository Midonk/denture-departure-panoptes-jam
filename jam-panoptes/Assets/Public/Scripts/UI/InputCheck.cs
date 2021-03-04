
using UnityEngine;
using UnityEngine.UI;

public class InputCheck : MonoBehaviour
{
    public Button moveUp;
    public Button moveRight;
    public Button moveDown;
    public Button moveLeft;
    public Button interact;
    public Button fire;
    
    private Image moveUpImg;
    private Image moveRightImg;
    private Image moveDownImg;
    private Image moveLeftImg;
    private Image interactImg;
    private Image fireImg;

    [Header("Colors")]
    public Color unpressed;
    public Color pressed;

    private Image[] inputs;

    private void OnEnable() {
        moveUpImg = moveUp.GetComponent<Image>();
        moveRightImg = moveRight.GetComponent<Image>();
        moveDownImg = moveDown.GetComponent<Image>();
        moveLeftImg = moveLeft.GetComponent<Image>();
        interactImg = interact.GetComponent<Image>();
        fireImg = fire.GetComponent<Image>();

        inputs = new Image[]{moveUpImg, moveDownImg, moveLeftImg, moveRightImg, interactImg, fireImg};
        foreach(Image input in inputs){
            input.color = unpressed;
        }
    }

    private void Update() {
         moveUpImg.color = InputManager.Instance.RawMovementDirection.y > 0 ? pressed : unpressed;
        moveRightImg.color = InputManager.Instance.RawMovementDirection.x > 0 ? pressed : unpressed;
        moveDownImg.color = InputManager.Instance.RawMovementDirection.y < 0 ? pressed : unpressed;
        moveLeftImg.color = InputManager.Instance.RawMovementDirection.x < 0 ? pressed : unpressed;
        interactImg.color = InputManager.Instance.Interact ? pressed : unpressed;
        fireImg.color = InputManager.Instance.Shoot ? pressed : unpressed; 
    }
}
