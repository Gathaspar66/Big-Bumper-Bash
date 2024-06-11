using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFrontLights : MonoBehaviour
{
    public void AcrivateCarFrontLights()
    {
        FrontLightsControllerScript.frontLightsController.ToggleLightsOnButton();
    }
}