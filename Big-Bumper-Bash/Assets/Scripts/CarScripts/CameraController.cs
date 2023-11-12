using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTarget;
    private Rigidbody carRigidbody;
    public Vector3 offset;
    public float followSpeed = 10.0f;
    private Vector3 lookDirection;
    private Quaternion targetRotation;
    private Vector3 targetPosition;
    private Vector3 desiredVelocity;
    private Rigidbody cameraRigidbody;
    private float followSpeedMultiplier = 1;

    private void Start()
    {
        cameraRigidbody = GetComponent<Rigidbody>();
        carRigidbody = GameManager.gameManager.GetPlayerCar().GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }

    private void LookAtTarget()
    {
        lookDirection = cameraTarget.position - transform.position;
        targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        cameraRigidbody.rotation = targetRotation;
    }

    private void MoveToTarget()
    {
        targetPosition = cameraTarget.position +
                         cameraTarget.forward * offset.z +
                         Vector3.up * offset.y;

        followSpeed = carRigidbody.velocity.magnitude * followSpeedMultiplier;

        desiredVelocity = (targetPosition - transform.position) * followSpeed;
        cameraRigidbody.velocity = desiredVelocity;
    }

    public void SetCameraFollowSpeed(float speed)
    {
        followSpeedMultiplier = speed;
    }
}