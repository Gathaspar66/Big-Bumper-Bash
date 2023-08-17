using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChoiceScript : MonoBehaviour
{
    public GameObject car1Button, car2Button, backButton;
    public GameObject backMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PressCar1()
    {
        print("starting game - car1");
        //gameObject.SetActive(false);
    }

    public void PressCar2()
    {
        print("starting game - car2");
        //gameObject.SetActive(false);
    }

    public void PressBack()
    {
        backMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}