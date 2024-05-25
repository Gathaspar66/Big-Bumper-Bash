using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundsManagerScript : MonoBehaviour
{
    public AudioSource mainMusic;
    public Map loadedTrackChoice;
    public AudioClip menuMusic;
    public AudioClip snowMapMusic;
    public AudioClip constructionMapMusic;
    public AudioClip testTracMusic;
    public AudioClip checkPointMusic;
    public static SoundsManagerScript soundsManager { get; private set; }
    public float volume;
    public AudioMixer AudioMixerPrefab;
    
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
    private void Update()
    {
        AudioMixerPrefab.SetFloat("MasterVolume", volume);
    }
    private void Start()
    {
        mainMusic = GetComponent<AudioSource>();

    }
    public void PlayMusic(Map loadedTrackChoice)
    {
        switch (loadedTrackChoice)
        {
            case Map.SNOW_MAP_NORMAL:
            case Map.SNOW_MAP_REVERSE:
            case Map.SNOW_MAP_ODD:
                PlaySingleMusic(snowMapMusic);
                break;
            case Map.CONSTRUCTION_MAP_NORMAL:
            case Map.CONSTRUCTION_MAP_REVERSE:
            case Map.CONSTRUCTION_MAP_ODD:
                PlaySingleMusic(constructionMapMusic);
                break;
            case Map.TEST_TRACK_MAP_NORMAL:
            case Map.TEST_TRACK_MAP_REVERSE:
            case Map.TEST_TRACK_MAP_ODD:
                PlaySingleMusic(testTracMusic);
                break;
        }
    }
    public void PlaySingleMusic(AudioClip music)
    {
        mainMusic.clip = music;
        mainMusic.Play();
        
    }
    public void PlayMenuMusic()
    {
        mainMusic.clip = menuMusic;
        mainMusic.Play();
    }

    public void PlayCheckPointMusic()
    {
        mainMusic.clip = checkPointMusic;
        mainMusic.Play();
    }


}
