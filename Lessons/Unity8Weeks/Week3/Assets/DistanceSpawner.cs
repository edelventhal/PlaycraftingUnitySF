using System.Collections.Generic;
using UnityEngine;

public class DistanceSpawner : Spawner
{
    [Tooltip ("When this thing changes position, we might spawn something.")]
    public Transform target;

    [Tooltip ("How big of an area can we randomly spawn within.")]
    public Rect spawnRange;

    [Tooltip ("How far does the target need to go to spawn something.")]
    public float distanceRequiredToSpawn;

    [Tooltip ("If true, we'll use the distance of the target from the spawn target instead.")]
    public bool useDistanceFromSpawnTarget;

    [Tooltip ("The minimum Y position we can spawn in.")]
    public float minY;

    [Tooltip ("The maximum Y position we can spawn in.")]
    public float maxY;

    //store the last target position that we spawned something
    protected Vector3 lastSpawnPosition;
    
    public void Start() 
    {
        if ( target == null )
        {
            return; //GTFO
        }
        
        lastSpawnPosition = target.position;
    }

    public void Update()
    {
        if ( target == null )
        {
            return; //GTFO
        }

        Vector3 targetPosition = target.position;

        //use the distance from the last spawn target
        if ( useDistanceFromSpawnTarget )
        {
            if ( Mathf.Abs( targetPosition.x - spawnTarget.transform.position.x ) <= distanceRequiredToSpawn )
            {
                Spawn();
            }
        }
        //use the distance the target has traveled in general
        else 
        {
            if ( Vector3.Distance( targetPosition, lastSpawnPosition ) >= distanceRequiredToSpawn )
            {
                Spawn();
            }
        }
    }

    public override GameObject Spawn()
    {
        GameObject obj = base.Spawn();

        Vector3 newPosition = obj.transform.position + new Vector3( spawnRange.x + Random.Range( 0.0f, spawnRange.width  ),
                                                                    spawnRange.y + Random.Range( 0.0f, spawnRange.height ), 
                                                                    obj.transform.position.z );
        
        newPosition.y = Mathf.Clamp( newPosition.y, minY, maxY );
        obj.transform.position = newPosition;
        
        spawnTarget = obj.transform;

        if ( target != null )
        {
            lastSpawnPosition = target.position;
        }

        return obj;
    }
}
