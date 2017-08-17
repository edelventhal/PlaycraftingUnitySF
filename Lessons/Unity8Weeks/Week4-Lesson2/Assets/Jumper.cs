using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class Jumper : MonoBehaviour
{
    public float jumpImpulse = 10.0f;

    protected Rigidbody body;
    protected NavMeshAgent agent;

    public void Awake()
    {
        body = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update() 
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            Jump();
        }
    }
    
    public void Jump()
    {
        body.isKinematic = false;
        body.velocity = agent.velocity * 2;
        agent.enabled = false;
        body.AddForce( Vector3.up * jumpImpulse );
    }

    public void OnCollisionEnter(Collision other)
    {
        //if ( other.collider is TerrainCollider )
        if ( other.collider.gameObject == Terrain.activeTerrain.gameObject )
        {
            agent.enabled = true;
            agent.velocity = body.velocity;
            body.isKinematic = true;
        }
    }
}
