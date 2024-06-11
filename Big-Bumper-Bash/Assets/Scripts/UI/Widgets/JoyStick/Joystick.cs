using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform Background;
    public RectTransform Handle;
    private Vector2 inputVector = Vector2.zero;

    private Vector2 initialTouchPosition = Vector2.zero;

    public static Joystick joystick { get; private set; }

    private void Awake()
    {
        if (joystick != null && joystick != this)
        {
            Destroy(this);
        }
        else
        {
            joystick = this;
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Background.gameObject.SetActive(true);
        initialTouchPosition = eventData.position;
        Background.position = eventData.position;
        Handle.anchoredPosition = Vector2.zero;
        OnDrag(eventData); // Call OnDrag to handle initial input
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector2
            touchDirection =
                eventData.position - initialTouchPosition; // Calculate the direction from initial touch position
        float joystickRadius = Background.sizeDelta.x / 2f; // Get the radius of the joystick background


        inputVector = (touchDirection.magnitude > joystickRadius)
            ? touchDirection.normalized
            : touchDirection / joystickRadius;

        inputVector = new Vector2(inputVector.x, 0f); // Constrain the joystick to horizontal movement

        Handle.anchoredPosition = inputVector * joystickRadius; // Move the handle based on the input
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Background.gameObject.SetActive(false); // Hide the joystick background
        inputVector = Vector2.zero; // Reset the input vector
        Handle.anchoredPosition = Vector2.zero; // Reset the handle position
    }


    public float Horizontal
    {
        get { return inputVector.x; }
    }


    public float Vertical
    {
        get { return inputVector.y; }
    }
}