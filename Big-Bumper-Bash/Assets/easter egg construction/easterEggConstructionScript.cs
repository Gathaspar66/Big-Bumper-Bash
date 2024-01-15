using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easterEggConstructionScript : MonoBehaviour
{
    public GameObject craneEnd, easterEggObject, crane_ODD;
    // Start is called before the first frame update
    void Start()
    {
        Activate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        craneEnd.SetActive(false);
        crane_ODD.SetActive(false);
        easterEggObject.SetActive(true);
        //disable ui, car controls etc
        easterEggObject.GetComponent<Animator>().Play("getup");
    }
}
