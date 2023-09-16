using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;
    private Vector3 newPosition;
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
