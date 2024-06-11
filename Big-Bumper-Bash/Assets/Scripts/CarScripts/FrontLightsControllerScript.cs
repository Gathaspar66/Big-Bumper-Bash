using UnityEngine;

public class FrontLightsControllerScript : MonoBehaviour
{
    public Light leftLight;
    public Light rightLight;
    private bool lightsOn = false;
    private Material material;
    private Color init;
    private Renderer rendererR;
    public static FrontLightsControllerScript frontLightsController { get; private set; }

    private void Awake()
    {
        if (frontLightsController != null && frontLightsController != this)
        {
            Destroy(this);
        }
        else
        {
            frontLightsController = this;
        }
    }

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

    public void ToggleLightsOnButton()
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

    void SetLightsActiveStatus(bool isActive)
    {
        leftLight.enabled = isActive;
        rightLight.enabled = isActive;
    }

    private void SetInitialColor()
    {
        rendererR = GetComponent<Renderer>();
        material = rendererR.material;
        init = material.GetColor("_EmissionColor");
    }
}