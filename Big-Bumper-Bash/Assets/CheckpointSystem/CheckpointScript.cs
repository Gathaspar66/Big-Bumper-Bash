using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CheckpointManagerScript.checkpointManager.OnCheckpointReached();
        gameObject.SetActive(false);
    }
}
