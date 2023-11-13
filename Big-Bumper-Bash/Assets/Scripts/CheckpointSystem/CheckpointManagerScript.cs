using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManagerScript : MonoBehaviour
{
    public static CheckpointManagerScript checkpointManager { get; private set; }

    public List<GameObject> checkpoints = new();
    public GameObject mapNormal;
    public GameObject mapReverse;
    public GameObject mapOdd;
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
        if (GameManager.gameManager.loadedGameModeChoice == GameMode.FREEPLAY) return;
        SelectCheckpointsForTrack();
        
    }

    public void SelectCheckpointsForTrack()
    {
        Transform checkpointsToAdd = transform;
        switch (GameManager.gameManager.loadedTrackChoice)
        {
            case Map.SNOW_MAP_NORMAL or Map.CONSTRUCTION_MAP_NORMAL or Map.TEST_TRACK_MAP:
                mapNormal.SetActive(true);
                AssignCheckpoints(mapNormal);

                break;

            case Map.SNOW_MAP_REVERSE or Map.CONSTRUCTION_MAP_REVERSE:
                mapReverse.SetActive(true);
                AssignCheckpoints(mapReverse);

                break;

            case Map.SNOW_MAP_ODD or Map.CONSTRUCTION_MAP_ODD:
                mapOdd.SetActive(true);
                AssignCheckpoints(mapOdd);

                break;
        }

        checkpoints[0].SetActive(true);
    }

    void AssignCheckpoints(GameObject source)
    {
        foreach(GameObject child in source.transform)
        {
            checkpoints.Add(child);
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