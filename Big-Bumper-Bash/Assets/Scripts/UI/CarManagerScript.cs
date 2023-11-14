using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;
using UnityEngine.Rendering.PostProcessing;

public class CarManagerScript : MonoBehaviour
{
    public GameObject ogierPrefab;
    public GameObject unikaczPrefab;

    public GameObject startPositionNormal;
    public GameObject startPositionReverse;
    public GameObject startPositionOdd;
    Transform startPosition;

    private GameObject playerCar;
    private Camera mainCamera;

    public GameObject snow;
    public static CarManagerScript CarManager { get; private set; }


    private void Awake()
    {
        if (CarManager != null && CarManager != this)
        {
            Destroy(this);
        }
        else
        {
            CarManager = this;
        }
    }

    public void Activate()
    {
        SetCarPosition();
        SpawnCar();
        SetWeather();
    }

    private void SetCarPosition()
    {
        switch (GameManager.gameManager.loadedTrackChoice)
        {
            case Map.SNOW_MAP_NORMAL or Map.CONSTRUCTION_MAP_NORMAL or Map.TEST_TRACK_MAP:

                startPosition = startPositionNormal.transform;

                break;

            case Map.SNOW_MAP_REVERSE or Map.CONSTRUCTION_MAP_REVERSE:

                startPosition = startPositionReverse.transform;

                break;

            case Map.SNOW_MAP_ODD or Map.CONSTRUCTION_MAP_ODD:

                startPosition = startPositionOdd.transform;

                break;
        }
    }

    public void SetActiveCarMovement(bool enabled)
    {
        GameManager.gameManager.GetPlayerCar().GetComponent<CarMovement>().EnableInput(enabled);
    }

    public void SpawnCar()
    {
        print("spawn car not ok ");
        switch (GameManager.gameManager.loadedCarChoice)
        {
            case Car.CAR1_OGIER:
                playerCar = Instantiate(ogierPrefab,
                    startPosition.position,
                    startPosition.rotation);


                break;

            case Car.CAR2_UNIKACZ:
                playerCar = Instantiate(unikaczPrefab,
                    startPosition.position,
                    startPosition.rotation);

                break;
        }

        print("spawn car ok ");
        GameManager.gameManager.SetPlayerCar(playerCar);
    }

    public void SetWeather()
    {
        mainCamera = GameManager.gameManager.GetPlayerCar().GetComponentInChildren<Camera>();


        switch (GameManager.gameManager.loadedTrackChoice)
        {
            case Map.SNOW_MAP_NORMAL:

                Instantiate(snow, mainCamera.transform.position, mainCamera.transform.rotation,
                    mainCamera.transform);


                break;

            case Map.SNOW_MAP_REVERSE:


                break;
        }
    }
}