using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TrackManagerScript : MonoBehaviour
{
    public GameObject[] normalSnowTrack;
    public GameObject[] reverseSnowTrack;

    public GameObject[] normalConstructionMapTrack;
    public GameObject[] reverseConstructionMapTrack;


    public static TrackManagerScript TrackManager { get; private set; }
    private Map track;


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


    public void SetObjectActive()
    {
        switch (GameManager.gameManager.loadedTrackChoice)
        {
            case Map.SNOW_MAP_NORMAL:


                foreach (GameObject objectOfArray in normalSnowTrack)
                {
                    objectOfArray.SetActive(true);
                }

                break;

            case Map.SNOW_MAP_REVERSE:

                foreach (GameObject objectOfArray in reverseSnowTrack)
                {
                    objectOfArray.SetActive(true);
                }

                break;
        }
    }
}