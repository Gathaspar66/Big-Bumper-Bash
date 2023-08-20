using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    public Button defaultSelected;
    public GameObject backButton;
    public GameObject backMenu;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        defaultSelected.GetComponent<Button>().Select();
    }

    public void PressBack()
    {
        backMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
