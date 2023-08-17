using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuScript : MonoBehaviour
{
    public GameObject backButton;
    public GameObject backMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PressBack()
    {
        backMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
