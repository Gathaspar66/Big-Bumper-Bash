using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject playButton, optionsButton, exitButton;
    public GameObject playMenu, optionsMenu, exitMenu;

    // Start is called before the first frame update
    void Start()
    {
        playButton.GetComponent<Button>().Select();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PressPlay()
    {
        playMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PressOptions()
    {
        optionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PressExit()
    {
        Application.Quit();
    }
}
