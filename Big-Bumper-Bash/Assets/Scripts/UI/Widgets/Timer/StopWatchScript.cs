using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StopWatchScript : MonoBehaviour
{
    float timeElapsed = 0f;
    private bool startCountTime = false;
    public TextMeshProUGUI timeText;
    public static StopWatchScript stopWatch { get; private set; }
    public int seconds;
    public int milliseconds;

    private void Awake()
    {
        if (stopWatch != null && stopWatch != this)
        {
            Destroy(this);
        }
        else
        {
            stopWatch = this;
        }
    }


    public void Update()
    {
        TimeCount();
    }

    public void StartTime()
    {
        startCountTime = true;
    }

    public void OnRaceFinished()
    {
        startCountTime = false;
        GameManager.gameManager.SaveBestTime(timeElapsed);
    }


    public void TimeCount()
    {
        if (!startCountTime) return;

        timeElapsed += Time.deltaTime;

        ShowTime(timeElapsed);
    }


    public void ShowTime(float timeElapsed)
    {
        seconds = Mathf.FloorToInt(timeElapsed);
        milliseconds = Mathf.FloorToInt((timeElapsed - seconds) * 1000);
        timeText.text = seconds.ToString("D2") + "." + milliseconds.ToString("D3") + "s";
    }
}