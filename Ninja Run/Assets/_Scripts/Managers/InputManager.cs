using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour         //regelt alles was mit Inputs zu tun hat z.B. Inputs wechseln
{
    public PlayerInput control;
    public bool playerActionMapActive;


    public void SwitchActionMap()       //Ändert die Steuerung auf UI/Spieler um
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
