using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChoiceScript : MonoBehaviour
{
    public GameObject map1Button, map2Button, backButton;
    public GameObject carChoiceMenu, backMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PressMap1()
    {
        carChoiceMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PressMap2()
    {
        carChoiceMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PressBack()
    {
        backMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}