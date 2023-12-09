using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class TrackLoader : MonoBehaviour
{
    public static void LoadTrack()
    {
        switch ((Map)PlayerPrefs.GetInt("mapChoice"))
        {
            case Map.SNOW_MAP_NORMAL:
            case Map.SNOW_MAP_REVERSE:
            case Map.SNOW_MAP_ODD:
                SceneManager.LoadScene("Snow_Map");
                break;

            case Map.CONSTRUCTION_MAP_NORMAL:
            case Map.CONSTRUCTION_MAP_REVERSE:
            case Map.CONSTRUCTION_MAP_ODD:
                SceneManager.LoadScene("Construction_Map");
                break;

            case Map.TEST_TRACK_MAP_NORMAL:
            case Map.TEST_TRACK_MAP_REVERSE:
            case Map.TEST_TRACK_MAP_ODD:
                SceneManager.LoadScene("TestTrack_Map");
                break;
        }
    }
}
