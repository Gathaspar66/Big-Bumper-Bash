using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainbowColorScript : MonoBehaviour
{
    List<Color32> colors = new List<Color32>{
        new Color32(255, 0, 0, 255),
        new Color32(255, 165, 0, 255),
        new Color32(255, 255, 0, 255),
        new Color32(0, 255, 0, 255),
        new Color32(0, 0, 255, 255),
        new Color32(75, 0, 130, 255),
        new Color32(238, 130, 238, 255)
        };
    float lerpCounter = 0;
    int currentColor, targetColor;
    Material mat;
    public Color cl;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        currentColor = 0;
        targetColor = 1;
    }

    // Update is called once per frame
    void Update()
    {
        lerpCounter += Time.deltaTime * 1;
        if (lerpCounter >=1) {
            lerpCounter = 0;
            IncrementColor();
        }
        UpdateColor();
    }

    void UpdateColor()
    {
        cl = Color.Lerp(colors[currentColor], colors[targetColor], lerpCounter);
        mat.color = cl;
        mat.SetColor("_EmissionColor", cl);
    }

    void IncrementColor()
    {
        currentColor += 1;
        if (currentColor >= colors.Count) currentColor = 0;
        targetColor = currentColor + 1;
        if (targetColor >= colors.Count) targetColor = 0;
    }
}
