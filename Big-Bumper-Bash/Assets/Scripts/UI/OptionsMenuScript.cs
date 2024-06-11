using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    public static OptionsMenuScript optionsMenu { get; private set; }
    public Slider masterVolumeSlider;
    public Slider mainMusicSlider;
    public Slider soundEffectsSldier;

    private void Awake()
    {
        if (optionsMenu != null && optionsMenu != this)
        {
            Destroy(this);
        }
        else
        {
            optionsMenu = this;
        }
    }

    public void Start()
    {
        masterVolumeSlider.value = SoundsManagerScript.soundsManager.masterVolume;
        mainMusicSlider.value = SoundsManagerScript.soundsManager.mainMusicVolume;
        soundEffectsSldier.value = SoundsManagerScript.soundsManager.soundEffectsVolume;
    }

    public void ChangeMasterVolume()
    {
        SoundsManagerScript.soundsManager.ChangeMasterVolume();
    }

    public void ChangeMainMusic()
    {
        SoundsManagerScript.soundsManager.ChangeMainMusic();
    }

    public void ChangeSoundEffect()
    {
        SoundsManagerScript.soundsManager.ChangeSoundEffect();
    }
}