using System.Collections;
using UnityEngine;

public class CarCrowdDriving : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed = 5f; 
    public float delayBetweenPoints = 1f; 
    private int currentPointIndex = 0;

    void Start()
    {
        StartCoroutine(MoveToPointRoutine());
    }

    IEnumerator MoveToPointRoutine()
    {
        while (true)
        {
            if (points.Length > 0)
            {
                Vector3 direction = (points[currentPointIndex].position - transform.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;
                transform.position += direction * moveSpeed * Time.deltaTime;
                if (Vector3.Distance(transform.position, points[currentPointIndex].position) < 0.1f)
                {
                    currentPointIndex = (currentPointIndex + 1) % points.Length;
                    yield return new WaitForSeconds(delayBetweenPoints);
                }
            }
            yield return null;
        }
    }
}
