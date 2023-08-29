using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LogoScript : MonoBehaviour
{
    Vector3 startPos;
    float moveRange = 2;
    float rotationRange = 15;
    float scaleRange = 3;
    float scalePulseDirection = 3;
    float pulseGrowSpeed = 20;
    float pulseShrinkSpeed = 0.8f;

    bool pulsate = true;

    public GameObject bashModel;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        scaleRange = Mathf.Sqrt(scaleRange);
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }

    void Animate()
    {
        Move();
        Rotate();
        Pulsate();
    }

    void Move()
    {
        transform.position = startPos + Vector3.right * (Mathf.PingPong(Time.time, moveRange) - moveRange / 2);
    }

    void Rotate()
    {
        transform.rotation = Quaternion.Euler(Mathf.PingPong(Time.time, rotationRange) - rotationRange / 2, -90, 0);
    }

    void Pulsate()
    {
        if (!pulsate) return;
        VerifyScalePulseDirection();
        bashModel.transform.localScale += Vector3.one * Time.deltaTime * scalePulseDirection;
    }

    void VerifyScalePulseDirection()
    {
        if (bashModel.transform.localScale.x >= scaleRange)
        {
            scalePulseDirection = -1 * pulseShrinkSpeed;
        }
        if (bashModel.transform.localScale.x <= 1)
        {
            scalePulseDirection = 1 * pulseGrowSpeed;
        }
    }

    public void Activate()
    {
        Rigidbody rb;
        pulsate = false;
        foreach (Transform logoPart in bashModel.transform)
        {
            //logoPart.transform.parent = null;
            rb = logoPart.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddExplosionForce(200, bashModel.transform.position, 5, 3);
        }
    }
}
