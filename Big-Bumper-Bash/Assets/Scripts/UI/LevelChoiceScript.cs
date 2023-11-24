using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelChoiceScript : MonoBehaviour
{
    //order corresponds to Enumerators.cs
    //public List<Texture> levelTextures = new();
    public List<Material> levelTextures = new();
    public List<string> levelNames = new();
    int currentChoice = 0;
    int maxChoice = 0;

    //public RawImage mapThumbnail;
    public GameObject screen;
    public TextMeshProUGUI mapName;
    public TextMeshProUGUI mapTime;

    private void Start()
    {
        maxChoice = levelTextures.Count - 1;
        UpdateChoice();
        UpdateTime();
        UpdateThumbnail();
    }

    void Update()
    {
        GetInput();
    }
    
    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeChoice(-1);
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            ChangeChoice(1);
        }
        UpdateChoice();
        UpdateTime();
        UpdateThumbnail();
    }

    public void ChangeChoice(int change)
    {
        currentChoice += change;
        if (currentChoice > maxChoice) currentChoice = 0;
        if (currentChoice < 0) currentChoice = maxChoice;
    }

    public void ChangeChoiceFromButton(int change)
    {
        SelectFirstButton();
        currentChoice += change;
        if (currentChoice > maxChoice) currentChoice = 0;
        if (currentChoice < 0) currentChoice = maxChoice;
    }

    private void SelectFirstButton()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out Button btn))
            {
                btn.Select();
                break;
            }
        }
    }

    public void UpdateChoice()
    {
        mapName.text = levelNames[currentChoice];
        MenuManager.menuManager.ChooseMap(currentChoice);
    }

    public void UpdateTime()
    {
        //mapTime.text = currentChoice.ToString();
        string time = "--:--:--";
        float loadedTime = PlayerPrefs.GetFloat("bestTime" + PlayerPrefs.GetInt("mapChoice"));
        if(loadedTime > 0)
        {
            time = loadedTime.ToString();
        }
        mapTime.text = "Best time: " + time;
    }

    public void UpdateThumbnail()
    {
        //mapThumbnail.texture = levelTextures[currentChoice];
        screen.GetComponent<Renderer>().material = levelTextures[currentChoice];
    }

    public void SaveMapChoice()
    {
        MenuManager.menuManager.ChooseMap(currentChoice);
    }
}
