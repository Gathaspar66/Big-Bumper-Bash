using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VehicleSpeedController : MonoBehaviour
{
    public Rigidbody carRigidbody;
    public TextMeshProUGUI speedText;
    private Vector3 carSpeed;
    float scalarSpeed;
    void Update()
    {
        SetSpeed();
        SetDisplayText();
    }





    public void SetSpeed()
    {
        carSpeed = carRigidbody.velocity;
        scalarSpeed = carSpeed.magnitude * 2;
    }




    public void SetDisplayText()
    {
        speedText.text = "Speed: " + scalarSpeed.ToString("F0");
    }

}
