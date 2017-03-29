using UnityEngine;

public class TimedDestructor : Destructor
{
    public Destructible destroyedDestructible;

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
