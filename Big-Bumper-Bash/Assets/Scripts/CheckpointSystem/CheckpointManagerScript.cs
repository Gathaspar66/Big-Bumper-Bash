using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManagerScript : MonoBehaviour
{
    public static CheckpointManagerScript checkpointManager { get; private set; }

    public List<GameObject> checkpoints = new();
    public List<GameObject> mapNormal = new();
    public List<GameObject> mapReverse = new(); 
    public List<GameObject> mapOdd = new();
    int checkpointNumber = 0;

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
    }

    public void Activate()
    {
        SetupCheckpoints();
        SelectCheckpointsForTrack();
        
    }

    public void SelectCheckpointsForTrack()
    {
        switch (GameManager.gameManager.loadedTrackChoice)
        {
            case Map.SNOW_MAP_NORMAL or Map.CONSTRUCTION_MAP_NORMAL or Map.TEST_TRACK_MAP:

                checkpoints = mapNormal;

                break;

            case Map.SNOW_MAP_REVERSE or Map.CONSTRUCTION_MAP_REVERSE:

                checkpoints = mapReverse;

                break;

            case Map.SNOW_MAP_ODD or Map.CONSTRUCTION_MAP_ODD:

                checkpoints = mapOdd;

                break;
        }

        checkpoints[0].SetActive(true);
    }


    void SetupCheckpoints()
    {
        DeactivateCheckpointsList(mapNormal);
        DeactivateCheckpointsList(mapReverse);
        DeactivateCheckpointsList(mapOdd);
    }

    void DeactivateCheckpointsList(List<GameObject> list)
    {
        foreach (GameObject checkpoint in list)
        {
            checkpoint.SetActive(false);
        }
    }

    public Transform GetFirstCheckpointPosition()
    {
        if (checkpoints.Count > 0)
        {
            GameObject firstCheckpoint = checkpoints[0];
            return firstCheckpoint.transform;
        }
        else
        {
            Debug.LogError("List is empty.");
            return null;
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
            checkpointNumber++;
            ArrowController.arrowController.SetUpTarget(checkpoints[checkpointNumber]);
            checkpoints[checkpointNumber].SetActive(true);
        }
    }

    bool IsLastCheckpointReached()
    {
        return checkpointNumber == checkpoints.Count - 1;
    }

    void OnLastCheckpointReached()
    {
        GameManager.gameManager.OnRaceFinished();
    }
}