using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager menuManager { get; private set; }
    public GameObject carContainerObject;
    public Vector3 lastCameraLocation, currentCameraLocation;
    public Quaternion lastCameraRotation, currentCameraRotation;
    float cameraSpeed = 1;
    float cameraMovementLerp = 0;
    bool moveCamera = false;
    public GameObject SoundsManagerPrefab;

    public List<RectTransform> menuPanels = new();
    public float targetSize = 0.8f; //by options menu being the tallest column
    
    private void Awake()
    {
        if (menuManager != null && menuManager != this)
        {
            Destroy(this);
        }
        else
        {
            menuManager = this;
        }
    }
    private void Start()
    {
        SoundsManagerScript.soundsManager.PlayMenuMusic();
        RecalculateMenuScale();
    }
    private void Update()
    {
        //kamera lerpa do lokacji aktualnej i jakis bool czy cos, lerp powinien byc 100% accurate do lokacji i rotacji
        //czyli git 
        MoveCamera();
    }

    void MoveCamera()
    {
        if (!moveCamera) return;

        cameraMovementLerp += Time.deltaTime * cameraSpeed;
        Camera.main.transform.position = Vector3.Lerp(lastCameraLocation, currentCameraLocation, cameraMovementLerp);
        Camera.main.transform.rotation = Quaternion.Lerp(lastCameraRotation, currentCameraRotation, cameraMovementLerp);

        if(cameraMovementLerp >= 1) moveCamera = false;
    }

    void StartCameraMovement(GameObject newCam)
    {
        lastCameraLocation = Camera.main.transform.position;
        currentCameraLocation = newCam.transform.position;
        lastCameraRotation = Camera.main.transform.rotation;
        currentCameraRotation = newCam.transform.rotation;
        cameraMovementLerp = 0;
        moveCamera = true;
    }

    private void SelectFirstButton(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.TryGetComponent(out Button btn))
            {
                btn.Select();
                break;
            }
        }
    }

    public void ChangeMenu(GameObject newMenu)
    {
        //hide all menu panels
        foreach (Transform menuChild in transform)
        {
            menuChild.gameObject.SetActive(false);
        }

        //hide all cars
        foreach (Transform menuChild in carContainerObject.transform)
        {
            menuChild.gameObject.SetActive(false);
        }

        newMenu.SetActive(true);

        StartCameraMovement(newMenu.GetComponent<GetMenuCamera>().GetCamera());

        SelectFirstButton(newMenu);
        if (newMenu.TryGetComponent<IActivable>(out IActivable component))
        {
            component.Activate();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChooseGameMode(EnumModeChoice modeChoice)
    {
        PlayerPrefs.SetInt("modeChoice", (int)modeChoice.modeChoice);
    }

    public void ChooseMap(int mapChoice)
    {
        PlayerPrefs.SetInt("mapChoice", mapChoice);
        
    }
   
    public void ChooseCar(int carChoice)
    {
        PlayerPrefs.SetInt("carChoice", (int)carChoice);
    }

    public void LoadRace()
    {
        TrackLoader.LoadTrack();
    }

    public void RecalculateMenuScale()
    {
        int currentScreenHeight = Screen.height;
        int optionsBackPanelHeight = 600;
        float targetScale = currentScreenHeight * targetSize / optionsBackPanelHeight;
        /*foreach (RectTransform i in menuPanels)
        {
            i.localScale = Vector3.one * targetScale;
        }*/

        foreach (Transform menuChild in transform)
        {
            menuChild.GetComponent<RectTransform>().localScale = Vector3.one * targetScale;
        }
    }
}