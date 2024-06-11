using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SoundsManagerScript : MonoBehaviour
{
    public AudioSource mainMusicSource;

    public AudioMixer AudioMixerPrefab;

    public AudioClip mainMenuClip;
    public AudioClip snowMapClip;
    public AudioClip constructionMapMusicClip;
    public AudioClip testTracMusicClip;
    public AudioClip checkPointClip;

    public Slider masterVolumeSlider;
    public Slider mainMusicVolumeSlider;
    public Slider soundEffectsVolumeSlider;

    public float masterVolume;
    public float mainMusicVolume;
    public float soundEffectsVolume;
    public static SoundsManagerScript soundsManager { get; private set; }

    private void Awake()
    {
        if (soundsManager != null && soundsManager != this)
        {
            Destroy(this);
        }
        else
        {
            soundsManager = this;
        }
    }

    private void Start()
    {
        mainMusicSource = GetComponent<AudioSource>();
        LoadVolume();
    }

    public void PlayMusicOnTheMap(Map loadedTrackChoice)
    {
        switch (loadedTrackChoice)
        {
            case Map.SNOW_MAP_NORMAL:
            case Map.SNOW_MAP_REVERSE:
            case Map.SNOW_MAP_ODD:
                PlaySingleMusic(snowMapClip);
                break;
            case Map.CONSTRUCTION_MAP_NORMAL:
            case Map.CONSTRUCTION_MAP_REVERSE:
            case Map.CONSTRUCTION_MAP_ODD:
                PlaySingleMusic(constructionMapMusicClip);
                break;
            case Map.TEST_TRACK_MAP_NORMAL:
            case Map.TEST_TRACK_MAP_REVERSE:
            case Map.TEST_TRACK_MAP_ODD:
                PlaySingleMusic(testTracMusicClip);
                break;
        }
    }

    public void PlaySingleMusic(AudioClip music)
    {
        LoadVolume();
        mainMusicSource.clip = music;
        mainMusicSource.Play();
    }

    public void PlayMenuMusic()
    {
        LoadVolume();
        mainMusicSource.clip = mainMenuClip;
        mainMusicSource.Play();
    }

    public void ChangeMasterVolume()
    {
        AudioMixerPrefab.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        SaveVolume("MasterVolume", OptionsMenuScript.optionsMenu.masterVolumeSlider.value);
    }

    public void ChangeMainMusic()
    {
        AudioMixerPrefab.SetFloat("MainMusicVolume", PlayerPrefs.GetFloat("MainMusicVolume"));
        SaveVolume("MainMusicVolume", OptionsMenuScript.optionsMenu.mainMusicSlider.value);
    }

    public void ChangeSoundEffect()
    {
        AudioMixerPrefab.SetFloat("SoundEffectsVolume", PlayerPrefs.GetFloat("SoundEffectsVolume"));
        SaveVolume("SoundEffectsVolume", OptionsMenuScript.optionsMenu.soundEffectsSldier.value);
    }

    public void SaveVolume(string typeOfVolume, float volume)
    {
        PlayerPrefs.SetFloat(typeOfVolume, Mathf.Log10(volume)*20);
    }

    public void LoadVolume()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        AudioMixerPrefab.SetFloat("MasterVolume", masterVolume);

        mainMusicVolume = PlayerPrefs.GetFloat("MainMusicVolume");
        AudioMixerPrefab.SetFloat("MainMusicVolume", mainMusicVolume);

        soundEffectsVolume = PlayerPrefs.GetFloat("SoundEffectsVolume");
        AudioMixerPrefab.SetFloat("SoundEffectsVolume", soundEffectsVolume);
    }
}