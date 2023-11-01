using UnityEngine;

public class FrontLightsControllerScript : MonoBehaviour
{
    public Light leftLight;
    public Light rightLight;
    private bool lightsOn = false;
    private Material material;
    private Color init;
    private Renderer renderer;

    void Start()
    {
        SetLightsActiveStatus(false);

        SetInitialColor();
    }

    void Update()
    {
        ToggleLightsOnKey();
    }

    private void ToggleLightsOnKey()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            lightsOn = !lightsOn;
            SetLightsActiveStatus(lightsOn);


            if (lightsOn)
            {
                material.SetColor("_EmissionColor", new Color(2.0f, 2f, 0f, 0.0f));
            }
            else
            {
                material.SetColor("_EmissionColor", init);
            }
        }
    }


    void SetLightsActiveStatus(bool isActive)
    {
        leftLight.enabled = isActive;
        rightLight.enabled = isActive;
    }

    private void SetInitialColor()
    {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
        init = material.GetColor("_EmissionColor");
    }
}