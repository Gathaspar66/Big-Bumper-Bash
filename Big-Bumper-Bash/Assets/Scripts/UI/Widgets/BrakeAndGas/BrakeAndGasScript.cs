using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeAndGasScript : MonoBehaviour
{
    public void SetMoveToDefault()
    {
        CarMovement.carMovement.SetMoveToDefault();
    }

    public void MoveForward()
    {
        CarMovement.carMovement.MoveForward();
    }

    public void MoveBackward()
    {
        CarMovement.carMovement.MoveBackward();
    }
}