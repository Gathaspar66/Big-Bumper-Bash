using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManagerScript : MonoBehaviour
{
    public static CheckpointManagerScript CheckpointManager;

    public List<GameObject> checkpoints= new();
    int currentCheckpoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        CheckpointManager = this;
        if (checkpoints.Count > 0)
        {
            foreach (GameObject checkpoint in checkpoints)
            {
                checkpoint.SetActive(false);
            }
            checkpoints[0].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckpointReached()
    {
        if (currentCheckpoint == checkpoints.Count - 1)
        {
            RaceFinished();
        }
        else
        {
            currentCheckpoint++;
            checkpoints[currentCheckpoint].SetActive(true);
        }
    }

    void RaceFinished()
    {
    }
}
