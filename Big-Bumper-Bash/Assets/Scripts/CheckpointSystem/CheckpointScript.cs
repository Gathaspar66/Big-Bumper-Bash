using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckpointScript : MonoBehaviour
{
    string layer;
    private void OnTriggerEnter(Collider other)
    {
        layer = LayerMask.LayerToName(other.gameObject.layer);
        print(layer + " " + other.gameObject.name);
       
        if (layer == "Player")
        {
            CheckpointManagerScript.checkpointManager.OnCheckpointReached();
            gameObject.SetActive(false);
        }
      
    }
}
