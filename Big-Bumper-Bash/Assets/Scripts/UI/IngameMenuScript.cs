using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameMenuScript : MonoBehaviour
{
    public static IngameMenuScript ingameMenu { get; private set; }
    public GameObject endScreen;

    bool isMenuOpen = false;
    bool levelEnded = false;

    private void Awake()
    {
        if (ingameMenu != null && ingameMenu != this)
        {
            Destroy(this);
        }
        else
        {
            ingameMenu = this;
        }
    }

    private void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (levelEnded)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                ToggleMenu();
            }
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
        DisableAllSubmenus();

        newMenu.SetActive(true);
        SelectFirstButton(newMenu);
        if (newMenu.TryGetComponent<IActivable>(out IActivable component))
        {
            component.Activate();
        }
    }

    void DisableAllSubmenus()
    {
        foreach (Transform menuChild in transform)
        {
            menuChild.gameObject.SetActive(false);
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadRace()
    {
        TrackLoader.LoadTrack();
    }

    public void ToggleMenu()
    {
        if (levelEnded) return;
        if (isMenuOpen)
        {
            DisableAllSubmenus();
            StopGameTime(false);
        }
        else
        {
            foreach (Transform menuChild in transform)
            {
                menuChild.gameObject.SetActive(true);
                SelectFirstButton(menuChild.gameObject);
                break;
            }
            StopGameTime(true);
        }
        isMenuOpen = !isMenuOpen;
    }

    public void OnLevelEnded()
    {
        levelEnded = true;
        DisableAllSubmenus();
        ChangeMenu(endScreen);
        StartCoroutine(EndCameraWaitTime());
    }

    void StopGameTime(bool stop)
    {
        Time.timeScale = System.Convert.ToInt32(!stop);
    }

    public IEnumerator EndCameraWaitTime()
    {
        GameManager.gameManager.GetPlayerCar().GetComponentInChildren<CameraController>().SetCameraFollowSpeed(0.0f);
        yield return new WaitForSeconds(2f);
        GameManager.gameManager.GetPlayerCar().GetComponentInChildren<CameraController>().SetCameraFollowSpeed(1.0f);
    }
}
