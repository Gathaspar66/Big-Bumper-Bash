using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StopWatchScript : MonoBehaviour
{
    float timeElapsed = 0f;
    private bool startCountTime = false;
    public TextMeshProUGUI timeText;
    public static StopWatchScript StopWatch { get; private set; }
    public int seconds;
    public int milliseconds;

    private void Awake()
    {
        if (StopWatch != null && StopWatch != this)
        {
            Destroy(this);
        }
        else
        {
            StopWatch = this;
        }
    }


    public void Update()
    {
        if (startCountTime)
        {
            TimeCount();
        }
    }

    public void StartTime()
    {
        startCountTime = true;
    }

    public void StopTime()
    {
        startCountTime = false;
    }


    public void TimeCount()
    {
        timeElapsed += Time.deltaTime;

        ShowTime(timeElapsed);
    }


    public void ShowTime(float timeElapsed)
    {
        seconds = Mathf.FloorToInt(timeElapsed);
        milliseconds = Mathf.FloorToInt((timeElapsed - seconds) * 1000);
        timeText.text = "Time: " + seconds.ToString("D2") + "." + milliseconds.ToString("D3") + "s";
    }
}