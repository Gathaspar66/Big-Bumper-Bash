using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarChoiceScript : MonoBehaviour
{
    public Button defaultSelected;
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

    private void OnEnable()
    {
        defaultSelected.GetComponent<Button>().Select();
    }

    public void PressCar(string car = "no car chosen")
    {
        print("starting game - car choice: " + car);
        //gameObject.SetActive(false);
    }

    public void PressBack()
    {
        backMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}