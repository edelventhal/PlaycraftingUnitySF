using System.Collections.Generic;
using UnityEngine;

//a Spawner that spawns when a trigger is hit
public class TriggerSpawner : Spawner
{
    [Tooltip ("Only objects with this mask can trigger collisions.")]
    public LayerMask triggerMask;

    public void OnTriggerEnter2D(Collider2D other)
    {
        //this is a bitwise operation, and the proper way to check collision layers...
        //yeesh! Just copy/paste it...
        if ( ((1<<other.gameObject.layer) & triggerMask) != 0 )
        {
            Spawn();
        }
    }
}
