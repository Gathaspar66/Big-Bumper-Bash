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

    public void OnCheckpointReached()
    {
        if (IsLastCheckpointReached())
        {
            OnLastCheckpointReached();
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

    void OnLastCheckpointReached()
    {
        GameManager.gameManager.OnRaceFinished();
    }
}
