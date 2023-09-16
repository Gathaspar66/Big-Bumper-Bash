using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager menuManager { get; private set; }

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
        foreach(Transform child in parent.transform)
        {
            child.GetComponent<Button>().Select();
            break;
        }
    }

    public void ChangeMenu(GameObject newMenu)
    {
        foreach (Transform menuChild in transform)
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

    public void ChooseMap(EnumMapChoice mapChoice)
    {
        PlayerPrefs.SetInt("mapChoice", (int)mapChoice.mapChoice);
    }

    public void ChooseCar(EnumCarChoice carChoice)
    {
        PlayerPrefs.SetInt("carChoice", (int)carChoice.carChoice);
    }

    public void LoadRace()
    {
        SceneManager.LoadScene("test track");
    }
}
