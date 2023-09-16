using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ogierPrefab;
    public GameObject unikaczPrefab;

    GameObject playerCar;

    public static GameManager gameManager { get; private set; }

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
        LoadRaceSettings();
    }

    void DebugLoadedSettings()
    {
        print("carChoice: " + PlayerPrefs.GetInt("carChoice") + " " + (Car)PlayerPrefs.GetInt("carChoice"));
        print("modeChoice: " + PlayerPrefs.GetInt("modeChoice") + " " + (GameMode)PlayerPrefs.GetInt("modeChoice"));
        print("mapChoice: " + PlayerPrefs.GetInt("mapChoice") + " " + (Map)PlayerPrefs.GetInt("mapChoice"));
    }

    void LoadRaceSettings()
    {
        SetupCar();
        SetupWidgets();
        SetupTrack();

        StartRace();
    }

    void SetupCar()
    {
        switch((Car)PlayerPrefs.GetInt("carChoice"))
        {
            case Car.CAR1_OGIER:
                playerCar = Instantiate(ogierPrefab);
                break;

            case Car.CAR2_UNIKACZ:
                playerCar = Instantiate(unikaczPrefab);
                break;
        }
    }

    void SetupWidgets()
    {
        //initialize and activate widgets here
    }

    void SetupTrack()
    {
        //checkpoints inform the widget manager and whatever cleanup left here
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
}
