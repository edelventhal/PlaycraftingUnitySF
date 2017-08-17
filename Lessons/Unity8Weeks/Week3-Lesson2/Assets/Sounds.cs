using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public OneShotSound soundPrefab;

    private List<OneShotSound> soundPool;

    private static Sounds instance;
    private static Sounds Instance 
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    public void Awake()
    {
        Instance = this;
        soundPool = new List<OneShotSound>();
    }
    
    public static void Play( AudioClip sound, float volume = 1.0f )
    {
        OneShotSound oneShotSound = Instance.CreateOneShotSound();
        oneShotSound.PlaySound( sound );
    }

    public static void Play( AudioClip[] sounds, float volume = 1.0f )
    {
        if ( sounds.Length <= 0 )
        {
            return;
        }
        
        Play( sounds[Random.Range(0,sounds.Length)], volume );
    }

    public static void DestroyOneShotSound( OneShotSound destroyedSound )
    {
        Instance.soundPool.Add( destroyedSound );
        destroyedSound.gameObject.SetActive( false );
    }

    private OneShotSound CreateOneShotSound()
    {
        if ( soundPool.Count > 0 )
        {
            OneShotSound oneShotSound = soundPool[0];
            oneShotSound.gameObject.SetActive(true);
            soundPool.RemoveAt(0);
            return oneShotSound;
        }
        
        return Instantiate<OneShotSound>( Instance.soundPrefab );
    }
}
