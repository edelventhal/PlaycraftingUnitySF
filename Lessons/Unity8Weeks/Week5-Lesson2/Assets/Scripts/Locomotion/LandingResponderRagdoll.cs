using UnityEngine;
using UnityEngine.AI;

public class LandingResponderRagdoll : LandingResponder
{
    [Tooltip ("If you want to spawn a ragdoll prefab upon landing incorrectly, use this.")]
    public Ragdoll spawnedRagdollPrefab;

    [Tooltip ("If you want to activated an attached ragdoll on landing, use this.")]
    public RagdollAttached attachedRagdoll;

    protected Ragdoll spawnedRagdoll;

    public override void Landed()
    {
        if ( spawnedRagdollPrefab != null && !CanLandAtPosition() )
        {
            CreateSpawnedRagdoll();
        }
        else if ( attachedRagdoll != null && !CanLandAtPosition() )
        {
             attachedRagdoll.RagdollEnabled = true;
        }
    }

    public override bool CanLand()
    {
        if ( spawnedRagdollPrefab != null )
        {
            if ( spawnedRagdoll != null )
            {
                return CanLandAtPosition();
            }
        }
        else if ( attachedRagdoll != null )
        {
            return CanLandAtPosition();
        }

        return true;
    }

    public void Update() 
    {
        if ( attachedRagdoll != null && attachedRagdoll.RagdollEnabled && CanLandAtPosition() )
        {
            attachedRagdoll.RagdollEnabled = false;
        }
    }

    protected bool CanLandAtPosition()
    {
        Vector3 searchPos = transform.position;

        if ( attachedRagdoll != null && attachedRagdoll.RagdollEnabled && attachedRagdoll.mainRigidbody != null )
        {
            searchPos = attachedRagdoll.mainRigidbody.transform.position;
        }

        NavMeshHit hit;
        return NavMesh.SamplePosition( searchPos, out hit, 0.25f, NavMesh.AllAreas );
    }

    protected void CreateSpawnedRagdoll()
    {
        spawnedRagdoll = Instantiate<Ragdoll>( spawnedRagdollPrefab );
        spawnedRagdoll.SourceObject = gameObject;
    }
}
