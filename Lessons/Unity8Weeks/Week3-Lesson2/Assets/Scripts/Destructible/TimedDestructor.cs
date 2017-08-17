using System.Collections.Generic;
using UnityEngine;

public class TimedDestructor : Destructor
{
    public float lifetime;

    protected float startTime;

    public void Start ()
    {
        startTime = Time.time;
    }
    
    public void Update ()
    {
        if ( Time.time - startTime >= lifetime )
        {
            DoDamage( destroyedDestructible );
        }
    }
}
