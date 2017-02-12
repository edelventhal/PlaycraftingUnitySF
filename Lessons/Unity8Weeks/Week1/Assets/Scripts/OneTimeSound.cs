using UnityEngine;

//this is a simple class that can play a single sound and then destroys
//itself once the sound is done playing. Works in combination with the Sounds class.
public class OneTimeSound : MonoBehaviour
{
    protected bool hasPlayed = false;
    
    public void Play( AudioClip sound )
    {
        GetComponent<AudioSource>().clip = sound;
        GetComponent<AudioSource>().Play();
        hasPlayed = true;
    }
    
    public void Update()
    {
        if ( hasPlayed && !GetComponent<AudioSource>().isPlaying )
        {
            Object.Destroy( gameObject );
        }
    }
}