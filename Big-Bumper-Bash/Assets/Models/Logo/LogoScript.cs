using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LogoScript : MonoBehaviour
{
    public GameObject bashModel;

    Vector3 startPos;
    float moveRange = 2;
    float rotationRange = 15;
    float scaleRange = 3;
    float scalePulseDirection = 3;
    float pulseGrowSpeed = 20;
    float pulseShrinkSpeed = 0.8f;

    float ragdollStartTime;
    float ragdollDuration = 2;
    float letterReturnCounter = 0;
    float returnSpeed = 1;

    BashLettersState letterState = BashLettersState.PULSE;

    List<Vector3> letterPartsStartingPositions = new();
    List<Transform> letterPartsTransforms = new();


    // Start is called before the first frame update
    void Start()
    {
        LogoSetup();
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }

    void LogoSetup()
    {
        startPos = transform.position;
        scaleRange = Mathf.Sqrt(scaleRange);
        foreach (Transform letterPart in bashModel.transform)
        {
            letterPartsTransforms.Add(letterPart);
        }
    }

    void Animate()
    {
        Move();
        Rotate();
        UpdateBashLetters();
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
        ChangeState(BashLettersState.RAGDOLL);
    }

    void UpdateBashLetters()
    {
        switch(letterState)
        {
            case BashLettersState.PULSE:
                PulseState();
                break;


            case BashLettersState.RAGDOLL:
                RagdollState();
                break;


            case BashLettersState.RETURN:
                ReturnState();
                break;
        }
    }

    void ChangeState(BashLettersState newState)
    {
        letterState = newState;
        switch (letterState)
        {
            case BashLettersState.PULSE:
                break;

            case BashLettersState.RAGDOLL:
                SetupRagdollState();
                break;

            case BashLettersState.RETURN:
                SetupReturnState();
                break;
        }
    }

    void SetupRagdollState()
    {
        Rigidbody rb;
        ragdollStartTime = Time.time;
        foreach (Transform letterPart in letterPartsTransforms)
        {
            rb = letterPart.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddExplosionForce(200, bashModel.transform.localPosition, 5, 3);
        }
    }

    void SetupReturnState()
    {
        Rigidbody rb;
        foreach (Transform letterPart in letterPartsTransforms)
        {
            rb = letterPart.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            letterPart.localRotation = Quaternion.Euler(-90, 0, 0);
            letterPartsStartingPositions.Add(letterPart.localPosition);
            print(letterPart.name + " " + letterPart.localPosition);
        }
    }

    void PulseState()
    {
        Pulsate();
    }

    void RagdollState()
    {
        if (IsRagdollTimeLimitReached())
        {
            ChangeState(BashLettersState.RETURN);
        }
    }

    void ReturnState()
    {
        if (letterReturnCounter > 1)
        {
            ChangeState(BashLettersState.PULSE);
        }
        letterReturnCounter += Time.deltaTime * returnSpeed;
        for (int i = 0; i < letterPartsTransforms.Count; i++)
        {
            letterPartsTransforms[i].localPosition = Vector3.Lerp(letterPartsStartingPositions[i], Vector3.zero, letterReturnCounter);
        }
    }

    bool IsRagdollTimeLimitReached()
    {
        return ragdollStartTime + ragdollDuration < Time.time;
    }
}
