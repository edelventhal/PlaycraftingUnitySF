using System.Collections.Generic;
using UnityEngine;

public class OffscreenDestructor : Destructor
{
    public float xDifferenceFromCameraForDestruction;
    
    public void Update ()
    {
        if ( Mathf.Abs( Camera.main.transform.position.x - destroyedDestructible.transform.position.x ) >= xDifferenceFromCameraForDestruction )
        {
            DoDamage( destroyedDestructible );
        }
    }
}
