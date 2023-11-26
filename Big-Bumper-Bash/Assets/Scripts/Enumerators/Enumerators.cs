using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Car
{
    CAR1_OGIER,
    CAR2_UNIKACZ,
    CAR3_FORKLIFT
}

public enum Map
{
    SNOW_MAP_NORMAL,
    SNOW_MAP_REVERSE,
    SNOW_MAP_ODD,
    CONSTRUCTION_MAP_NORMAL,
    CONSTRUCTION_MAP_REVERSE,
    CONSTRUCTION_MAP_ODD,
    TEST_TRACK_MAP
}

public enum GameMode
{
    RACE,
    FREEPLAY
}

public enum CarFunction
{
    GETINPUT,
    RIGIDBODY
}

public enum BashLettersState
{
    PULSE,
    RAGDOLL,
    RETURN
}

public enum Widget
{
    ARROW,
    SPEEDOMETER,
    MINIMAP,
    STOPWATCH,
    LAPCOUNTER,
    COUNTDOWN
}