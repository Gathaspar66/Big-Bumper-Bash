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
        DebugLoadedSettings();
        LoadTrackSetting();
        MapInitialization();
    }

    public void LoadTrackSetting() //Loads all the player's choices
    {
        loadedTrackChoice = (Map)PlayerPrefs.GetInt("mapChoice");
        loadedGameModeChoice = (GameMode)PlayerPrefs.GetInt("modeChoice");
        loadedCarChoice = (Car)PlayerPrefs.GetInt("carChoice");
    }

    void DebugLoadedSettings()
    {
        print("carChoice: " + PlayerPrefs.GetInt("carChoice") + " " + (Car)PlayerPrefs.GetInt("carChoice"));
        print("modeChoice: " + PlayerPrefs.GetInt("modeChoice") + " " + (GameMode)PlayerPrefs.GetInt("modeChoice"));
        print("mapChoice: " + PlayerPrefs.GetInt("mapChoice") + " " + (Map)PlayerPrefs.GetInt("mapChoice"));
    }

    void MapInitialization()
    {
        SetupTrack();


        SetupCar();
        SetupWidgets();
     

        StartRace();
    }

    void SetupCar()
    {
        CarManagerScript.CarManager.Activate();
    }

    void SetupWidgets()
    {
        //initialize and activate widgets here
    }

    void SetupTrack()
    {
        //checkpoints inform the widget manager and whatever cleanup left here
        TrackManagerScript.TrackManager.SetObjectActive();
    }


    void StartRace()
    {
        //activate countdown
    }

    public void OnRaceStarted()
    {
        //enable controls, stopwatch, etc
    }

    public void OnRaceFinished()
    {
        //race ending activites here
    }

    public GameObject GetPlayerCar()
    {
        return playerCar;
    }

    public void SetPlayerCar(GameObject car)
    {
        playerCar = car;
    }
}