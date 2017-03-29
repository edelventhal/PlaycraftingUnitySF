using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LandingResponderTeleportBack : LandingResponder
{
    private Vector3 jumpStartPosition;

    public override void Jumped()
    {
        jumpStartPosition = transform.position;
    }
    
    public override void Landed()
    {
        if ( !CanLandAtPosition() )
        {
            transform.position = jumpStartPosition;
        }
    }

    public override bool CanLand()
    {
        if ( !CanLandAtPosition() )
        {
            return false;
        }

        return true;
    }

    protected bool CanLandAtPosition()
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition( transform.position, out hit, 0.25f, NavMesh.AllAreas );
    }
}
