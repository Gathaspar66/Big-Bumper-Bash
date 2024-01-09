using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CranePickupScript : MonoBehaviour
{
    public GameObject craneArm;
    public GameObject magnet;
    GameObject car;

    void Start()
    {
    }


    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        car = other.gameObject;
        car.GetComponent<Rigidbody>().isKinematic = true;
        car.transform.position = transform.position;
        car.transform.rotation = Quaternion.Euler(0, 90, 0);
        craneArm.GetComponent<Animator>().Play("crane pickup");
    }

    public void OnCarPickup()
    {
        car.transform.parent = magnet.transform;
    }

    public void OnCarDrop()
    {
        car.transform.parent = null;
        car.GetComponent<Rigidbody>().isKinematic = false;
    }
}