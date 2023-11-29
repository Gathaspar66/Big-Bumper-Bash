using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [Header("Wheel Trails")] public TrailRenderer trailFrontLeft;
    public TrailRenderer trailFrontRight;
    public TrailRenderer trailBackLeft;
    public TrailRenderer trailBackRight;

    [Header("Vehicle settings")] public AnimationCurve maxSteerAngle;
    public float motorForce = 1500;

    public Vector3 centerOfMass;
    public Rigidbody carRigidBody;
    public ParticleSystem wheelSmokeParticles;
    public float animatedCurveValue;
    public bool isControlEnabled = false;


    void Start()
    {
        SetupCenterOfMass();
    }

    private void Update()
    {
        GetInput();
    }

    private void LateUpdate()
    {
        Steer();
        Accelerate();
        UpdateWheelsPositions();
        CheckWheelSlip();
    }

    private void SetupCenterOfMass()
    {
        carRigidBody = GetComponent<Rigidbody>();
        carRigidBody.centerOfMass = centerOfMass;
    }

    public void GetInput()
    {
        if (!isControlEnabled)
        {
            m_horizontalInput = 0;
            m_verticalInput = 0;
        }
        else
        {
            m_horizontalInput = Input.GetAxis("Horizontal");
            m_verticalInput = Input.GetAxis("Vertical");
        }
    }

    public void EnableInput(bool enabled)
    {
        isControlEnabled = enabled;
    }

    private void Steer()
    {
        animatedCurveValue = maxSteerAngle.Evaluate(VehicleSpeedController.VehicleSpeed.scalarSpeed);


        m_steeringAngle = animatedCurveValue * m_horizontalInput;

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

    private void CheckWheelSlip()
    {
        CheckSingleWheelSlip(colliderFrontLeft, wheelFrontLeft, trailFrontLeft);
        CheckSingleWheelSlip(colliderFrontRight, wheelFrontRight, trailFrontRight);
        CheckSingleWheelSlip(colliderBackLeft, wheelBackLeft, trailBackLeft);
        CheckSingleWheelSlip(colliderBackRight, wheelBackRight, trailBackRight);
    }

    private void CheckSingleWheelSlip(WheelCollider collider, Transform transform, TrailRenderer trail)
    {
        if (collider.GetGroundHit(out WheelHit hit))
        {
            if ( Mathf.Abs(hit.sidewaysSlip) > 0.6f)// || Mathf.Abs(hit.forwardSlip) > 0.7f )
            {
                EmitWheelSmoke(transform.position, hit.normal);

                ToggleTrailEmission(trail, true);
            }
            else
            {
                ToggleTrailEmission(trail, false);
            }
        }
    }

    private void EmitWheelSmoke(Vector3 position, Vector3 normal)
    {
        Quaternion rotation = Quaternion.LookRotation(normal);
        ParticleSystem smoke = Instantiate(wheelSmokeParticles, position, rotation);
        smoke.Play();

        Destroy(smoke.gameObject, 0.2f);
    }


    private void ToggleTrailEmission(TrailRenderer trail, bool play)
    {
        trail.emitting = play;
    }
}