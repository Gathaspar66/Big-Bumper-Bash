using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManagerScript : MonoBehaviour
{
    public static CheckpointManagerScript checkpointManager { get; private set; }

    public List<GameObject> checkpoints = new();
    int currentCheckpoint = 0;

    private void Awake()
    {
        if (checkpointManager != null && checkpointManager != this)
        {
            Destroy(this);
        }
        else
        {
            checkpointManager = this;
        }
    }

    void Start()
    {
        SetupCheckpoints();
    }

    public void OnCheckpointReached()
    {
        if (IsLastCheckpointReached())
        {
            OnRaceFinished();
        }
        else
        {
            currentCheckpoint++;
            checkpoints[currentCheckpoint].SetActive(true);
        }
    }

    bool IsLastCheckpointReached()
    {
        return currentCheckpoint == checkpoints.Count - 1;
    }

    void SetupCheckpoints()
    {
        if (checkpoints.Count > 0)
        {
            foreach (GameObject checkpoint in checkpoints)
            {
                checkpoint.SetActive(false);
            }
            checkpoints[0].SetActive(true);
        }
    }

    void OnRaceFinished()
    {
        //TODO
        //initiate race ending e.g. disabling vehicle input, saving high score
    }
}
