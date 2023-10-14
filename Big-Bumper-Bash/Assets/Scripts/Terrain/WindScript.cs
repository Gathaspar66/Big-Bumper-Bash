using Unity.VisualScripting;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    public float maxRotationAngleX = 10.0f;
    public float rotationSpeed = 0.1f;

    private Vector3 initialRotation;
    private float pingPongTime = 0.0f;
    private float randomOffset;
    private float pingPongValue;
    private float rotationAngleX;
    private Quaternion targetRotation;

    void Start()
    {
        GetInitialRotation();
        GenerateRandomOffset();
    }

    void Update()
    {
        CalculateRotation();
        SetRotation();
    }

    void GetInitialRotation()
    {
        initialRotation = transform.eulerAngles;
    }

    void GenerateRandomOffset()
    {
        randomOffset = Random.Range(0.0f, 10.0f);
    }

    void CalculateRotation()
    {
        pingPongTime += Time.deltaTime * rotationSpeed;

        pingPongValue = Mathf.PingPong(pingPongTime + randomOffset, 2.0f) - 1.0f;
        rotationAngleX = pingPongValue * maxRotationAngleX;
    }

    void SetRotation()
    {
        targetRotation =
            Quaternion.Euler(initialRotation.x + rotationAngleX, initialRotation.y, initialRotation.z);
        transform.rotation = targetRotation;
    }
}