using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerDoorOpeningScript : MonoBehaviour
{

    public GameObject door1, door2;
    Transform from1, from2;
    public Transform to1, to2;
    public float speed = 0.3f;
    float timeCount = 0.0f;
    bool animateOpening = false;

    void Start()
    {
        from1 = door1.transform;
        from2 = door2.transform;
    }

    void Update()
    {
        if (animateOpening)
        {
            timeCount += Time.deltaTime;
            door1.transform.rotation = Quaternion.Lerp(from1.rotation, to1.rotation, timeCount * speed);
            door2.transform.rotation = Quaternion.Lerp(from2.rotation, to2.rotation, timeCount * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Collider>().enabled = false;
        animateOpening = true;
    }
}
