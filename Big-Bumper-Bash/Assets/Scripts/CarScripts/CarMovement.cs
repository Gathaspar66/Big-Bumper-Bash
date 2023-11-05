using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    private Vector3 pos;
    private Quaternion quat;

    [Header("Wheels colliders")] public WheelCollider colliderFrontLeft;
    public WheelCollider colliderFrontRight;
    public WheelCollider colliderBackLeft;
    public WheelCollider colliderBackRight;

    [Header("Wheels")] public Transform wheelFrontLeft;
    public Transform wheelFrontRight;
    public Transform wheelBackLeft;
    public Transform wheelBackRight;

    [Header("Vehicle settings")] public float maxSteerAngle = 30;
    public float motorForce = 1500;

    public Vector3 centerOfMass;
    public Rigidbody carRigidBody;
    public bool isControlEnabled = false;

    void Start()
    {
        SetupCenterOfMass();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Steer();
        Accelerate();
        UpdateWheelsPositions();
    }

    private void SetupCenterOfMass()
    {
        carRigidBody = GetComponent<Rigidbody>();
        carRigidBody.centerOfMass = centerOfMass;
    }

    public void GetInput()
    {
        if (!isControlEnabled) return;

        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    public void EnableInput(bool enabled)
    {
        isControlEnabled = enabled;
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