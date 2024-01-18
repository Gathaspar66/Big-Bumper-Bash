using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easterEggPickupScript : MonoBehaviour
{
    public AudioClip ring;
    public GameObject trigger;
    public GameObject crane;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.gameManager.loadedTrackChoice != Map.CONSTRUCTION_MAP_ODD)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0, Space.Self);
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 1) + 4, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(ring, 0.2f);
        trigger.SetActive(true);
        crane.SetActive(false);
        GetComponent<Collider>().enabled = false;
    }
}