using UnityEngine;

public class UIAnimationManager : MonoBehaviour
{
    public float movePositionX;
    public float movePositionY;
    public float animationDuration;
    public float animationDelay;

    public bool playOnStart = false;
    public bool moveX = false;
    public bool moveY = false;

    // Start is called before the first frame update
    void Start()
    {
        if(playOnStart)
        {
            if(moveX == true)
            {
                LeftToRightEntry();
            }
            if(moveY == true)
            {
                TopToBottomEntry();
            }
        }
    }

    void LeftToRightEntry()
    {
        LeanTween.moveLocalX(gameObject, movePositionX, animationDuration).setDelay(animationDelay).setEaseInOutBack();
    }

    void TopToBottomEntry()
    {
        LeanTween.moveLocalY(gameObject, movePositionY, animationDuration).setDelay(animationDelay).setEaseInOutBack();
    }
}
