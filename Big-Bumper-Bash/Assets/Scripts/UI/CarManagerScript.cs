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
        SpawnCar();
        SetWeather();
    }

    public void SpawnCar()
    {
        switch (GameManager.gameManager.loadedCarChoice)
        {
            case Car.CAR1_OGIER:
                playerCar = Instantiate(ogierPrefab);


                break;

            case Car.CAR2_UNIKACZ:
                playerCar = Instantiate(unikaczPrefab);

                break;
        }

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