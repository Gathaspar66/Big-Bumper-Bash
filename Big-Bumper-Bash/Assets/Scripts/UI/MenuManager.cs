using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager menuManager { get; private set; }
    public GameObject carContainerObject;

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

    private void SelectFirstButton(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            child.GetComponent<Button>().Select();
            break;
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
        SelectFirstButton(newMenu);
        if (newMenu.TryGetComponent<IActivable>(out IActivable component))
        {
            component.Activate();
        }
    }

    public void ExitGame()
    {
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
}