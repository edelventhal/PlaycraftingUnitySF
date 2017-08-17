using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OneShotSound : MonoBehaviour
{
    public float volume
    {
        get
        {
            return audioSource.volume;
        }
        set
        {
            audioSource.volume = value;
        }
    }

    protected AudioSource audioSource;

    public void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound( AudioClip sound )
    {
        audioSource.clip = sound;
        audioSource.Play();

        Invoke( "DestroyMe", audioSource.clip.length + 0.5f );
    }

    private void DestroyMe()
    {
        Sounds.DestroyOneShotSound( this );
    }
}
