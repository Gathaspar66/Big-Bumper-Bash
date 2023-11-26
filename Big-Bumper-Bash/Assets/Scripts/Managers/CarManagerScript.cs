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
    public GameObject forkliftPrefab;

    public GameObject startPositionNormal;
    public GameObject startPositionReverse;
    public GameObject startPositionOdd;
    Transform startPosition;
    Transform respawnPoint;
    bool canRespawn = false;

    private GameObject playerCar;
    private Camera mainCamera;

    public GameObject snow;
    public static CarManagerScript carManager { get; private set; }


    private void Awake()
    {
        if (carManager != null && carManager != this)
        {
            Destroy(this);
        }
        else
        {
            carManager = this;
        }
    }

    private void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        if (!canRespawn) return;
        if (Input.GetKeyDown(KeyCode.R))
        {
            //auto reset from falling out of the map should bypass this
            if (GameManager.gameManager.GetPlayerCar().GetComponent<Rigidbody>().velocity.magnitude > 1) return;
            ResetCar();
        }
    }

    public void Activate()
    {
        SetCarPosition();
        SpawnCar();
        SetWeather();
    }

    public void ResetCar()
    {
        GameManager.gameManager.GetPlayerCar().GetComponent<Rigidbody>().isKinematic = true;
        GameManager.gameManager.GetPlayerCar().transform.position = respawnPoint.transform.position;
        GameManager.gameManager.GetPlayerCar().transform.rotation = respawnPoint.transform.rotation;
        GameManager.gameManager.GetPlayerCar().GetComponent<Rigidbody>().isKinematic = false;
    }

    public void SetRespawnLocation(GameObject checkpoint)
    {
        SetRespawnLocation(checkpoint.transform);
    }

    public void SetRespawnLocation(Transform transform)
    {
        respawnPoint = transform;
    }

    private void SetCarPosition()
    {
        switch (GameManager.gameManager.loadedTrackChoice)
        {
            case Map.SNOW_MAP_NORMAL or Map.CONSTRUCTION_MAP_NORMAL or Map.TEST_TRACK_MAP_NORMAL:

                startPosition = startPositionNormal.transform;

                break;

            case Map.SNOW_MAP_REVERSE or Map.CONSTRUCTION_MAP_REVERSE or Map.TEST_TRACK_MAP_REVERSE:

                startPosition = startPositionReverse.transform;

                break;

            case Map.SNOW_MAP_ODD or Map.CONSTRUCTION_MAP_ODD or Map.TEST_TRACK_MAP_ODD:

                startPosition = startPositionOdd.transform;

                break;
        }

        SetRespawnLocation(startPosition);
    }

    public void SetActiveCarMovement(bool enabled)
    {
        GameManager.gameManager.GetPlayerCar().GetComponent<CarMovement>().EnableInput(enabled);
        canRespawn = enabled;
    }

    public void SpawnCar()
    {
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

            case Car.CAR3_FORKLIFT:
                playerCar = Instantiate(forkliftPrefab,
                    startPosition.position,
                    startPosition.rotation);

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

                Instantiate(snow, mainCamera.transform.position, mainCamera.transform.rotation,
                    mainCamera.transform);
                break;

            case Map.SNOW_MAP_ODD:

                Instantiate(snow, mainCamera.transform.position, mainCamera.transform.rotation,
                    mainCamera.transform);
                break;
        }
    }
}