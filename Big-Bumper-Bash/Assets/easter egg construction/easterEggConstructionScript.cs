using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easterEggConstructionScript : MonoBehaviour
{
    public GameObject craneEnd, easterEggObject, crane_ODD;
    public AudioClip song;
    AudioSource asrc;


    public bool doonce = false;
    // Start is called before the first frame update
    void Start()
    {
        easterEggObject.SetActive(false);
        asrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (doonce)
        {
            doonce = false;
            Activate();
        }
    }

    public void Activate()
    {
        asrc.PlayOneShot(song, 0.1f);
        craneEnd.SetActive(false);
        crane_ODD.SetActive(false);
        easterEggObject.SetActive(true);
        //disable ui, car controls etc
        easterEggObject.GetComponent<Animator>().Play("getup");
    }
}
