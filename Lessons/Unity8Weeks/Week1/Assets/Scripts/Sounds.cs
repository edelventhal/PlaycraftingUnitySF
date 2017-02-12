using UnityEngine;
using System.Collections.Generic;

//this is a handy library class that plays sounds quite simply so you can forget about them.
//normally, you'd need an AudioSource on anything you wanted to play sounds from.
//this is a static class – it cannot be created and only one will ever exist. It's similar
//to the "singleton" design pattern, but has different advantages and disadvantages.
//the nice thing with either is that we can access functions from it without needing to
//link to or create one of those objects.
public class Sounds : MonoBehaviour
{
    private static OneTimeSound oneTimeSoundPrefab;
    private static Dictionary<int,int> audioBuckets = new Dictionary<int,int>();
    
    private static void Initialize()
    {
        if ( oneTimeSoundPrefab == null )
        {
            //Resources.Load is actually NOT encouraged by Unity to be used, for various reasons.
            //it basically allows us to load something without it needing to be in the scene.
            //careful, this can cause hitches, since it will need to read from the disk.
            //in this case, we're grabbing a very simple prefab, so it's okay.
            oneTimeSoundPrefab = Resources.Load<GameObject>( "OneTimeSound" ).GetComponent<OneTimeSound>();
        }
    }
    
    //plays a random clip from the array from a list of clips that have been played the least
    //this is quite useful to avoid super repetitive sounds for common effects – you can have
    //many variants of the same sound, and that way it's less tiresome to hear.
    public static void Play( AudioClip[] sounds )
    {
        if ( sounds.Length <= 0 )
        {
            return;
        }
                
        if ( sounds.Length <= 1 )
        {
            Play( sounds[ 0 ] );
        }
        else
        {
            AudioClip leastCommonSound = sounds[ Random.Range( 0, sounds.Length ) ];
            int leastCommonCount = audioBuckets.ContainsKey( leastCommonSound.GetInstanceID() ) ? audioBuckets[ leastCommonSound.GetInstanceID() ] : 0;
            
            for ( int soundIndex = 0; soundIndex < sounds.Length; soundIndex++ )
            {
                int audioID = sounds[ soundIndex ].GetInstanceID();
                int count = 0;
                if ( audioBuckets.ContainsKey( audioID ) )
                {
                    count = audioBuckets[ audioID ];
                }
                
                if ( count < leastCommonCount )
                {
                    leastCommonSound = sounds[ soundIndex ];
                    leastCommonCount = count;
                }
            }
            
            audioBuckets[ leastCommonSound.GetInstanceID() ] = leastCommonCount + 1;
            Play( leastCommonSound );
        }
    }
    
    public static void Play( AudioClip sound )
    {
        Initialize();
        
        //when we play a sound, we simply create a copy of our sound prefab and have it play the sound we desire.
        //this is inefficient – the garbage collector will have a field day when tons of sounds are being played.
        //a better option would be to use what's called an "object pool", where we reuse old OneTimeSound objects.
        Object.Instantiate<OneTimeSound>( oneTimeSoundPrefab ).Play( sound );
    }
    
    //warning - inefficient. also, only stops OneTimeSound's, won't stop anything played by a different AudioSource
    public static void StopAll()
    {
        OneTimeSound[] sounds = Object.FindObjectsOfType<OneTimeSound>();
        for ( int soundIndex = 0; soundIndex < sounds.Length; soundIndex++ )
        {
            Object.Destroy( sounds[ soundIndex ].gameObject );
        }
    }
}