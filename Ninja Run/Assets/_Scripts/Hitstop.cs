using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitstop : MonoBehaviour
{
    bool isWaiting;

    public void Stop(float duration) //Stop Effekt wird ausgeführt
    {
        if (isWaiting && PauseMenu.GameIsPaused == true)
        {
            return;
        }
        Time.timeScale = 0.05f;
        StartCoroutine(Wait(duration));
    }

    IEnumerator Wait(float duration) //Stop Effekt wird wieder zurückgesetzt
    {

        yield return new WaitForSecondsRealtime(duration);
        if ( PauseMenu.GameIsPaused == true)
        {
            Time.timeScale = 0.0f;
        } else {
            Time.timeScale = 1.0f;
        }
    }
}
