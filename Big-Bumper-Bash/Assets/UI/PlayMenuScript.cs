using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenuScript : MonoBehaviour
{
    public Button defaultSelected;
    public GameObject freeplayButton, raceButton, backButton;
    public GameObject freeplayMenu, raceMenu, backMenu;

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

    public void OnFreeplayButtonPressed()
    {
        freeplayMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnRaceButtonPressed()
    {
        raceMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnBackButtonPressed()
    {
        backMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
