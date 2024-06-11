using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCarScript : MonoBehaviour
{
    public void resetCar()
    {
        CarManagerScript.carManager.ResetCar();
    }
}