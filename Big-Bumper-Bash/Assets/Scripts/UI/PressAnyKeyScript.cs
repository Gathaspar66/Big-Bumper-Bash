using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKeyScript : MonoBehaviour
{
    public GameObject mainMenu, logoObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            MenuManager.menuManager.ChangeMenu(mainMenu);
            gameObject.SetActive(false);
            logoObject.GetComponent<LogoScript>().Activate();
        }
    }
}
