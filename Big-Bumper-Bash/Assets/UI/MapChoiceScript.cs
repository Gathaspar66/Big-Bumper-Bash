using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapChoiceScript : MonoBehaviour
{
    public Button defaultSelected;
    public GameObject map1Button, map2Button, backButton;
    public GameObject carChoiceMenu, backMenu;

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

    public void OnMapButtonPressed(EnumMapChoice map)
    {
        carChoiceMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnBackButtonPressed()
    {
        backMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}