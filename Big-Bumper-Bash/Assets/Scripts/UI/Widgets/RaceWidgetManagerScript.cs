using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaceWidgetManagerScript : MonoBehaviour
{
    public GameObject arrow;
    public GameObject miniMap;
    public GameObject speed;
    public static RaceWidgetManagerScript raceWidgetManager { get; private set; }

    private void Awake()
    {
        if (raceWidgetManager != null && raceWidgetManager != this)
        {
            Destroy(this);
        }
        else
        {
            raceWidgetManager = this;
        }
    }

    void Start()
    {
    }

    void Update()
    {
    }

    public void SetActive(Widget widgetName, bool isActive)
    {
        switch (widgetName)
        {
            case Widget.ARROW:
                arrow.SetActive(isActive);
                break;

            case Widget.SPEEDOMETER:
                speed.SetActive(isActive);
                break;

            case Widget.MINIMAP:
                miniMap.SetActive(isActive);
                break;
        }
    }
}