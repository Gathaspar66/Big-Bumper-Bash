using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaceWidgetManagerScript : MonoBehaviour
{
    public GameObject arrow;
    public GameObject miniMap;
    public GameObject speed;
    public GameObject countdown;
    public GameObject stopWatch;
    public GameObject JoyStick;
    public GameObject options;
    public GameObject lights;
    public GameObject BrakeAndGas;
    public GameObject resetCar;
    public static RaceWidgetManagerScript raceWidgetManager { get; private set; }

    private void Awake()
    {
        if (raceWidgetManager != null && raceWidgetManager != this)
        {
            Destroy(this);
        }
        else
        {
            raceWidgetManager = this;
        }
    }


    public void Activate()
    {
        SetupWidgets();
    }


    public void SetupWidgets()
    {
        switch (GameManager.gameManager.loadedGameModeChoice)
        {
            case GameMode.FREEPLAY:

                speed.SetActive(true);
                countdown.SetActive(true);
                JoyStick.SetActive(true);
                options.SetActive(true);
                lights.SetActive(true);
                BrakeAndGas.SetActive(true);
                resetCar.SetActive(true);
                break;

            case GameMode.RACE:

                speed.SetActive(true);
                arrow.SetActive(true);
                miniMap.SetActive(true);
                countdown.SetActive(true);
                stopWatch.SetActive(true);
                JoyStick.SetActive(true);
                options.SetActive(true);
                lights.SetActive(true);
                BrakeAndGas.SetActive(true);
                resetCar.SetActive(true);

                break;
        }
    }

    public void OnRaceFinished()
    {
        speed.SetActive(false);
        arrow.SetActive(false);
        miniMap.SetActive(false);
        countdown.SetActive(false);
        JoyStick.SetActive(false);
        options.SetActive(false);
        lights.SetActive(false);
        BrakeAndGas.SetActive(false);
        resetCar.SetActive(false);
        StopWatchScript.stopWatch.OnRaceFinished();
    }

    internal void OnRaceStarted()
    {
        if (StopWatchScript.stopWatch != null) StopWatchScript.stopWatch.StartTime();
    }
}