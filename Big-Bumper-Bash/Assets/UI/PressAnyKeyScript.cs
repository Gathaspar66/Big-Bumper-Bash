using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKeyScript : MonoBehaviour
{
    public GameObject mainMenu, logoObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            mainMenu.SetActive(true);
            gameObject.SetActive(false);
            logoObject.GetComponent<LogoScript>().Activate();
        }
    }
}
