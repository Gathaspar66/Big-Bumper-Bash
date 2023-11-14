using System;
using UnityEngine;

public class BackLightsControllerScript : MonoBehaviour
{
    private Material material;
    private Color init;
    private Renderer rendererR;

    void Start()
    {
        SetInitialColor();
    }

    void Update()
    {
        OnSwitchEmissionKey();
    }

    private void OnSwitchEmissionKey()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            material.SetColor("_EmissionColor", new Color(2.0f, 0f, 0f, 0.0f));
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            material.SetColor("_EmissionColor", init);
        }
    }


    private void SetInitialColor()
    {
        rendererR = GetComponent<Renderer>();
        material = rendererR.material;
        init = material.GetColor("_EmissionColor");
    }
}