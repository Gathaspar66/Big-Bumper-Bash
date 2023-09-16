using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 offset;
    public float followSpeed = 10.0f;
    private Vector3 lookDirection;
    private Quaternion targetRotation;
    private Vector3 targetPosition;
    private Vector3 desiredVelocity;
    private Rigidbody cameraRigidbody;

    private void Start()
    {
        cameraRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }

    private void LookAtTarget()
    {
        lookDirection = targetObject.position - transform.position;
        targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        cameraRigidbody.rotation = targetRotation;
    }

    private void MoveToTarget()
    {
        targetPosition = targetObject.position +
                         targetObject.forward * offset.z +
                         Vector3.up * offset.y;

        followSpeed = targetObject.GetComponent<Rigidbody>().velocity.magnitude;

        desiredVelocity = (targetPosition - transform.position) * followSpeed;
        cameraRigidbody.velocity = desiredVelocity;
    }
}