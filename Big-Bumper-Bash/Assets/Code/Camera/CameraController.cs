using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 offset;
    public float followSpeed = 10.0f;
    public float lookSpeed = 10.0f;
    private Vector3 lookDirection;
    private Quaternion targetRotation;
    private Vector3 targetPosition;

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }

    private void LookAtTarget()
    {
        lookDirection = targetObject.position - transform.position;
        targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
    }

    private void MoveToTarget()
    {
        targetPosition = targetObject.position +
                                 targetObject.forward * offset.z +
                                 targetObject.right * offset.x +
                                 targetObject.up * offset.y;

        followSpeed = targetObject.GetComponent<Rigidbody>().velocity.magnitude;
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
