using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void setTimeScale(float scale)
    {
        Time.timeScale = scale;
    }


    public void slowToFast()
    {
        Time.timeScale = 0.25f;
        StartCoroutine(scaleIncreaser());
    }

    IEnumerator scaleIncreaser()
    {
        while (Time.timeScale < 1f)
        {
            yield return new WaitForEndOfFrame();
            Time.timeScale += 0.01f;
        }
        Time.timeScale = 1f;
    }
}
