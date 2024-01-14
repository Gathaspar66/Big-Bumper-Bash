using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainbowColorScript1 : MonoBehaviour
{
    List<Color32> colors = new List<Color32>{
        new Color32(255, 0, 0, 255),
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
        lerpCounter += Time.deltaTime * 2;
        if (lerpCounter >=1) {
            lerpCounter = 0;
            IncrementColor();
        }
        UpdateColor();
    }

    void UpdateColor()
    {
        //cl = Color.Lerp(colors[currentColor], new Color32(100, 0, 0, 255), lerpCounter);
        //mat.color = cl;
    }

    void IncrementColor()
    {
        currentColor += 1;
        if (currentColor >= colors.Count) currentColor = 0;
    }
}
