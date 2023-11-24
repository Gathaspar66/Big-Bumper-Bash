using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject playerCar;
    public static GameManager gameManager { get; private set; }
    public Map loadedTrackChoice;
    public GameMode loadedGameModeChoice;
    public Car loadedCarChoice;
    public Transform startPosition;

    private void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

    private void Start()
    {
        print( PlayerPrefs.GetFloat("bestTime" + PlayerPrefs.GetInt("mapChoice")));
        DebugLoadedSettings();

        LoadTrackSetting();
        MapInitialization();
    }

    void DebugLoadedSettings()
    {
        print("carChoice: " + PlayerPrefs.GetInt("carChoice") + " " + (Car)PlayerPrefs.GetInt("carChoice"));
        print("modeChoice: " + PlayerPrefs.GetInt("modeChoice") + " " + (GameMode)PlayerPrefs.GetInt("modeChoice"));
        print("mapChoice: " + PlayerPrefs.GetInt("mapChoice") + " " + (Map)PlayerPrefs.GetInt("mapChoice"));
    }

    public void LoadTrackSetting() //Loads all the player's choices
    {
        loadedTrackChoice = (Map)PlayerPrefs.GetInt("mapChoice");
        loadedGameModeChoice = (GameMode)PlayerPrefs.GetInt("modeChoice");
        loadedCarChoice = (Car)PlayerPrefs.GetInt("carChoice");
    }

    void MapInitialization()
    {
        SetupTrack();


        SetupCar();
        SetupWidgets();
    }

    void SetupTrack()
    {
        CheckpointManagerScript.checkpointManager.Activate();

        TrackManagerScript.TrackManager.Activate();
    }

    void SetupCar()
    {
        CarManagerScript.carManager.Activate();
    }

    void SetupWidgets()
    {
        RaceWidgetManagerScript.raceWidgetManager.Activate();
    }


    public void OnRaceStarted()
    {
        CarManagerScript.carManager.SetActiveCarMovement(true);

        RaceWidgetManagerScript.raceWidgetManager.OnRaceStarted();
    }

    public GameObject GetPlayerCar()
    {
        return playerCar;
    }

    public void SetPlayerCar(GameObject car)
    {
        playerCar = car;
    }

    public void OnRaceFinished()
    {
        RaceWidgetManagerScript.raceWidgetManager.OnRaceFinished();
        CarManagerScript.carManager.SetActiveCarMovement(false);
        IngameMenuScript.ingameMenu.OnLevelEnded();
    }

    public void SaveBestTime(float currentTime)
    {
        float bestTime = PlayerPrefs.GetFloat("bestTime" + PlayerPrefs.GetInt("mapChoice"));
        print("time check, current: " + currentTime + " best: " + bestTime);
        if (bestTime == 0 || currentTime < bestTime)
        {
            print("new best time");
            PlayerPrefs.SetFloat("bestTime" + PlayerPrefs.GetInt("mapChoice"), currentTime);
        }

    }
}