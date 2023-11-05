using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TrackManagerScript : MonoBehaviour
{
    public GameObject[] normalTrack;
    public GameObject[] reverseTrack;


    public static TrackManagerScript TrackManager { get; private set; }


    private void Awake()
    {
        if (TrackManager != null && TrackManager != this)
        {
            Destroy(this);
        }
        else
        {
            TrackManager = this;
        }
    }

    public void Activate()
    {
        SetObjectActive();
    }

    public void SetObjectActive()
    {
        switch (GameManager.gameManager.loadedTrackChoice)
        {
            case Map.SNOW_MAP_NORMAL:
            case Map.CONSTRUCTION_MAP_NORMAL:

                foreach (GameObject objectOfArray in normalTrack)
                {
                    objectOfArray.SetActive(true);
                }

                break;

            case Map.SNOW_MAP_REVERSE:
            case Map.CONSTRUCTION_MAP_REVERSE:
                foreach (GameObject objectOfArray in reverseTrack)
                {
                    objectOfArray.SetActive(true);
                }

                break;
        }
    }
}