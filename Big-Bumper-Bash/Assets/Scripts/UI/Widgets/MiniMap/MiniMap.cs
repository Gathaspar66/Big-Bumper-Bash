using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;
    private Vector3 newPosition;


    void Start()
    {
        player = GameManager.gameManager.GetPlayerCar().transform;
    }


    private void LateUpdate()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        if (player != null)
        {
            newPosition = player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
        }
    }
}