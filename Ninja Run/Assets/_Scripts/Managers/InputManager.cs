using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput control;
    public bool playerActionMapActive;


    public void SwitchActionMap()
    {
       if (playerActionMapActive)
       {
            control.actions.FindActionMap("Player").Disable();
            playerActionMapActive = false;
       }
       else
       {
            control.actions.FindActionMap("Player").Enable();
            playerActionMapActive = true;
       }
    }
}
