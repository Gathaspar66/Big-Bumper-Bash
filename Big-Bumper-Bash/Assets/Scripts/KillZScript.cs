using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZScript : MonoBehaviour
{
    string layer;
    private void OnTriggerEnter(Collider other)
    {
        
        layer = LayerMask.LayerToName(other.gameObject.layer);

        if (layer == "Player")
        {
            CarManagerScript.carManager.ResetCar();
            Debug.Log("<color=red>OUT OF BOUNDS: </color>" + other.gameObject.name + " with rigidbody: " + other.name + " fell out of bounds and called ResetCar()");
        }
        else
        {
            Destroy(other.gameObject);
        }
  
    }
}
