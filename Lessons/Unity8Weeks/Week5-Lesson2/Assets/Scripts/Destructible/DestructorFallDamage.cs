using System.Collections.Generic;
using UnityEngine;

public class DestructorFallDamage : Destructor
{
    public float minDamageForce = 5.0f;

    public Destructible destroyedDestructible;

    public void OnCollisionEnter(Collision other)
    {
        if ( other.relativeVelocity.magnitude >= minDamageForce && other.contacts[0].normal.y >= 0.7f )
        {
            DoDamage(destroyedDestructible);
        }
    }
}
