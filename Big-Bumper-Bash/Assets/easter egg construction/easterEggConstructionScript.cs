using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easterEggConstructionScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject craneEnd, easterEggObject, crane_ODD;
    public AudioClip song;
    AudioSource asrc;

    public bool doonce = true;

    // Start is called before the first frame update
    void Start()
    {
        easterEggObject.SetActive(false);
        asrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {/*
        if (doonce)
        {
            doonce = false;
            Activate();
        }*/
    }

    public void Activate()
    {
        if (doonce)
        {
            menu.SetActive(false);
            doonce = false;
            asrc.PlayOneShot(song, 0.1f);
            craneEnd.SetActive(false);
            crane_ODD.SetActive(false);
            easterEggObject.SetActive(true);
            //disable ui, car controls etc
            easterEggObject.GetComponent<Animator>().Play("getup");
        }
    }
    public void EndAnim()
    {
        menu.SetActive(true);
    }
}
