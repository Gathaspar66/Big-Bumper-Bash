using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CarChoiceScript : MonoBehaviour
{
    //order corresponds to Enumerators.cs
    public List<GameObject> carModels = new();
    public List<string> carNames = new();
    int currentChoice = 0;
    int maxChoice = 0;

    public TextMeshProUGUI carName;
    public TextMeshProUGUI carStats;

    private void Start()
    {
        maxChoice = carModels.Count - 1;
        UpdateChoice();
        UpdateTime();
        UpdateCarModel();
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
        UpdateCarModel();
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
        carName.text = carNames[currentChoice];
        MenuManager.menuManager.ChooseCar(currentChoice);
    }

    public void UpdateTime()
    {
        carStats.text = currentChoice.ToString();
    }

    private void UpdateCarModel()
    {
        foreach(GameObject car in carModels)
        {
            car.SetActive(false);
        }
        carModels[currentChoice].SetActive(true);
    }

    public void SaveCarChoice()
    {
        MenuManager.menuManager.ChooseCar(currentChoice);
    }

}
