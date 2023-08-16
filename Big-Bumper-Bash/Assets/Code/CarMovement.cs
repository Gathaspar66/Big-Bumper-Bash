using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider colliderFrontLeft, colliderFrontRight;
    public WheelCollider colliderBackLeft, colliderBackRight;
    public Transform wheelFrontLeft, wheelFrontRight;
    public Transform wheelBackLeft, wheelBackRight;
    public float maxSteerAngle = 30;
    public float motorForce = 1500;

    Vector3 pos;
    Quaternion quat;

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelsPositions();
    }
    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        colliderFrontLeft.steerAngle = m_steeringAngle;
        colliderFrontRight.steerAngle = m_steeringAngle;
    }

    private void Accelerate()
    {
        colliderFrontLeft.motorTorque = m_verticalInput * motorForce;
        colliderFrontRight.motorTorque = m_verticalInput * motorForce;
    }

    private void UpdateWheelsPositions()
    {
        UpdateWheelPosition(colliderFrontLeft, wheelFrontLeft);
        UpdateWheelPosition(colliderFrontRight, wheelFrontRight);
        UpdateWheelPosition(colliderBackLeft, wheelBackLeft);
        UpdateWheelPosition(colliderBackRight, wheelBackRight);
    }

    private void UpdateWheelPosition(WheelCollider collider, Transform transform)
    {
        pos = transform.position;
        quat = transform.rotation;

        collider.GetWorldPose(out pos, out quat);

        transform.position = pos;
        transform.rotation = quat;
    }
}
