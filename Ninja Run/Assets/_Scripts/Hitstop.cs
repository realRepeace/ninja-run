using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitstop : MonoBehaviour
{
    bool waiting;

    public void Stop(float duration) //Stop Effekt wird ausgeführt
    {
        if (waiting)
        {
            return;
        }
        Time.timeScale = 0.0f;
        StartCoroutine(Wait(duration));
    }

    IEnumerator Wait(float duration) //Stop Effekt wird wieder zurückgesetzt
    {
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
    }
}
