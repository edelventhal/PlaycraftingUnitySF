using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDelayer : MonoBehaviour
{
    public float minTimeBetweenSounds = 0.0f;
    public float maxTimeBetweenSounds = 1.0f;

    public void Start() 
    {
        SetUpNextInvoke();
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
        SetUpNextInvoke();
    }

    private void SetUpNextInvoke() 
    {
        Invoke( "PlaySound", Random.Range( minTimeBetweenSounds, maxTimeBetweenSounds ) );
    }
}
