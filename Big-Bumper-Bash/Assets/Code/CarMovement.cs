using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float acceleration = 5.0f;
    public float maxSpeed = 15.0f;
    public float brakingDeceleration = 20.0f;
    public float turnSpeed = 80.0f;

    private float currentSpeed = 0.0f;
    private float currentTurnSpeed = 0.0f;

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        HandleAccelerationAndBraking(verticalInput);
        UpdateMovement(verticalInput);
        UpdateTurning(verticalInput, horizontalInput);
    }

    private void HandleAccelerationAndBraking(float verticalInput)
    {
        if (verticalInput > 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        }
        else if (verticalInput < 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, -maxSpeed * 0.5f, brakingDeceleration * Time.deltaTime);
        }
    }
    
    private void UpdateMovement(float verticalInput)
    {
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    private void UpdateTurning(float verticalInput, float horizontalInput)
    {
        if (Mathf.Abs(verticalInput) > 0 || Mathf.Abs(horizontalInput) > 0)
        {
            currentTurnSpeed = horizontalInput * turnSpeed * currentSpeed / maxSpeed;
        }
        else
        {
            currentTurnSpeed = 0.0f;
        }

        transform.Rotate(Vector3.up * currentTurnSpeed * Time.deltaTime);
    }
}