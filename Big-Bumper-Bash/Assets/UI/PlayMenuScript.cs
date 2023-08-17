using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuScript : MonoBehaviour
{
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

    public void PressFreeplay()
    {
        freeplayMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PressRace()
    {
        raceMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PressBack()
    {
        backMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
