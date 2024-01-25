using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //CarManagerScript.carManager.ResetCar();

        //safety precaution
        Debug.Log("<color=red>OUT OF BOUNDS: </color>" + other.gameObject.name +" with rigidbody: " + other.name + " fell out of bounds and called ResetCar()");
    }
}
