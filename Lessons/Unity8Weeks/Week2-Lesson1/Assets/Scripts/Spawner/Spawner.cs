using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Rigidbody2D prefab;

    public float spawnInterval;

    public Vector3 spawnOffset;
    
    public float spawnPower;

    public Transform target;

    public void Start()
    {
        InvokeRepeating( "Spawn", spawnInterval, spawnInterval );
    }

    public void Spawn() 
    {
        if ( target == null )
        {
            return;
        }
        
        Rigidbody2D spawnedObject = Instantiate<Rigidbody2D>( prefab );
        spawnedObject.transform.position = transform.position + spawnOffset;

        Vector2 spawnForce = ( (Vector2) ( target.transform.position - transform.position ) ).normalized * spawnPower;
        spawnedObject.AddForce( spawnForce, ForceMode2D.Impulse );
    }
}
