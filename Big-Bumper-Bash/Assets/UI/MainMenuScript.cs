using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Button defaultSelected;
    public GameObject playButton, optionsButton, exitButton;
    public GameObject playMenu, optionsMenu, exitMenu;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        defaultSelected.GetComponent<Button>().Select();
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
