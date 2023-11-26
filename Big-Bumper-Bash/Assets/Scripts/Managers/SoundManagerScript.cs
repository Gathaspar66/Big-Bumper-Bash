using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioClip clip1, clip2, clip3;
    AudioSource asrc;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        asrc = GetComponent<AudioSource>();
        asrc.PlayOneShot(clip1);
    }

    private void Update()
    {
        if (!asrc.isPlaying)
        {
            if ( i > 2)
            {
                asrc.PlayOneShot(clip3);
                i = 0;
                return;
            }
            asrc.PlayOneShot(clip2);
            i++;

        }
    }
}
