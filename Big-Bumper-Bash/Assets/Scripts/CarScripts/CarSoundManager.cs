using System.Collections;
using UnityEngine;

public class CarSoundManager : MonoBehaviour
{
    public AudioSource skidSound;
    public Rigidbody carRigidbody;
    public float minSpeed = 0.5f;
    public float maxSpeed = 50f;
    public float minPitch = 0.1f;
    public float maxPitch = 2f;
    private float speed = 0;
    private float normalizedSpeed;
    private float pitch;
    public static CarSoundManager carSoundManager { get; private set; }
    public AudioSource carSound;

    private float skidFadeSpeed = 0.01f;
    private bool isFadingOut = false;
    private float startVolume = 0.3f;

    private void Awake()
    {
        if (carSoundManager != null && carSoundManager != this)
        {
            Destroy(this);
        }
        else
        {
            carSoundManager = this;
        }
    }

    void Start()
    {
    }

    void Update()
    {
        GetSpeed();
        PlayCarSound();
    }

    private void GetSpeed()
    {
        speed = carRigidbody.velocity.magnitude;
    }

    private void PlayCarSound()
    {
        //   normalizedSpeed = Mathf.InverseLerp(minSpeed, maxSpeed, speed);
        //   pitch = Mathf.Lerp(minPitch, maxPitch, normalizedSpeed);
        //carSound.pitch = pitch;

        pitch = speed * 0.04f;

        carSound.pitch = pitch;
    }

    public void PlaySkidSound(bool isPlayed)
    {
        if (isPlayed && !skidSound.isPlaying)
        {
            skidSound.volume = startVolume;
            skidSound.Play();
        }
        else
        {
            StartCoroutine(FadeOutSkidSound());
        }
    }

    IEnumerator FadeOutSkidSound()
    {
        isFadingOut = true; 

        while (skidSound.volume > 0.01f)
        {
            skidSound.volume =
                Mathf.Lerp(skidSound.volume, 0.0f,
                    Time.deltaTime * skidFadeSpeed);
            yield return null;
        }

        skidSound.Stop(); 
        isFadingOut = false;
    }
}