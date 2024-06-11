using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOptionsScript : MonoBehaviour
{
    public void ToggleMenu()
    {
        IngameMenuScript.ingameMenu.ToggleMenu();
    }
}