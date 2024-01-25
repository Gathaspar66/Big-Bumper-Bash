using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easterEggTriggerScript : MonoBehaviour
{
    public GameObject easterEgg;

    private void OnTriggerEnter(Collider other)
    {
        easterEgg.GetComponent<easterEggConstructionScript>().Activate();
        GameManager.gameManager.GetPlayerCar().GetComponent<Rigidbody>().isKinematic = true;
        CarManagerScript.carManager.SetActiveCarMovement(false);
        Destroy(gameObject);
    }
}
