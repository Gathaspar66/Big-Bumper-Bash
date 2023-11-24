using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VehicleSpeedController : MonoBehaviour
{
    public Rigidbody carRigidbody;
    public TextMeshProUGUI speedText;
    private Vector3 carSpeed;
    public float scalarSpeed;
    public static VehicleSpeedController VehicleSpeed { get; private set; }

    private void Awake()
    {
        if (VehicleSpeed != null && VehicleSpeed != this)
        {
            Destroy(this);
        }
        else
        {
            VehicleSpeed = this;
        }
    }

    void Update()
    {
        SetSpeed();
        SetDisplayText();
    }

    void Start()
    {
        carRigidbody = GameManager.gameManager.GetPlayerCar().GetComponent<Rigidbody>();
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