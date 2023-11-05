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
    public static ArrowController arrowController { get; private set; }


    private void Awake()
    {
        if (arrowController != null && arrowController != this)
        {
            Destroy(this);
        }
        else
        {
            arrowController = this;
        }
    }

    void Start()
    {
        car = GameManager.gameManager.GetPlayerCar().transform;
    }


    void Update()
    {
        RotateArrowTowardsTarget();
    }

    public void SetUpTarget(GameObject checkPoint)
    {
        target = checkPoint.transform;
    }


    private void RotateArrowTowardsTarget()
    {
        direction = target.position - car.position;
        angle = Vector3.SignedAngle(car.forward, direction, Vector3.up);

        targetRotation = Quaternion.Euler(0f, angle, 0f);
        arrow.rotation = Quaternion.Slerp(arrow.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}