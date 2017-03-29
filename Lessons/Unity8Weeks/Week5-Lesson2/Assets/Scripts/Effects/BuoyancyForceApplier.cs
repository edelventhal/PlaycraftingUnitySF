using UnityEngine;
using System.Collections.Generic;

public class BuoyancyForceApplier : MonoBehaviour
{
    public float buoyancyGravityMultiple = 1.2f;
    public float waterFrictionAmount = 0.1f;

    protected List<Rigidbody> floatingBodies;

    public void Awake() 
    {
        floatingBodies = new List<Rigidbody>();
    }

    public void OnTriggerEnter( Collider other )
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if ( rb != null && !floatingBodies.Contains( rb ) )
        {
            floatingBodies.Add( rb );
        }
    }

    public void OnTriggerExit( Collider other )
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if ( rb != null )
        {
            floatingBodies.Remove( rb );
        }
    }

    public void FixedUpdate() 
    {
        Vector3 buoyancyVelocity = Physics.gravity * -buoyancyGravityMultiple;

        for ( int bodyIndex = 0; bodyIndex < floatingBodies.Count; bodyIndex++ )
        {
            Rigidbody rb = floatingBodies[bodyIndex];
            if ( rb != null )
            {
                //first, add buoyancy force that counteracts gravity
                rb.AddForce( buoyancyVelocity * rb.mass );

                //then, scale all velocity down, since we're in water, unless we're floating upwards
                float friction = ( 1.0f - waterFrictionAmount * Time.fixedDeltaTime );
                Vector3 vel = rb.velocity;
                float initialVelY = vel.y;
                vel = rb.velocity * friction;
                if ( initialVelY > 0.0f )
                {
                    vel.y = initialVelY;
                }
                rb.velocity = vel;
            }
        }
    }
}
