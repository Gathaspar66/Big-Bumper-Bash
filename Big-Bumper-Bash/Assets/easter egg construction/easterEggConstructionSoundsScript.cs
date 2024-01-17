using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easterEggConstructionSoundsScript : MonoBehaviour
{
    public AudioSource asrc;
    public List<AudioClip> clips = new List<AudioClip>();
    public List<ParticleSystem> part = new List<ParticleSystem>();

    public void PlaySound(int index)
    {
        asrc.PlayOneShot(clips[index], 0.4f);
    }
    public void Particle(int index)
    {
        part[index].Play();
        asrc.PlayOneShot(clips[Random.Range(6, 8)], 0.4f);
    }
}
