using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Transform target;
    public Transform car;
    public Transform arrow;
    public float rotationSpeed = 5f;
    private float angle;
    private Vector3 direction;
    private Quaternion targetRotation;

    void Update()
    {
        RotateArrowTowardsTarget();
    }

    private void RotateArrowTowardsTarget()
    {
        direction = target.position - car.position;
        angle = Vector3.SignedAngle(car.forward, direction, Vector3.up);

        targetRotation = Quaternion.Euler(0f, angle, 0f);
        arrow.rotation = Quaternion.Slerp(arrow.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}