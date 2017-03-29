using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class DestructibleKnockedBack : Destructible
{
    public float knockbackForce = 100.0f;
    public float knockbackUpwardsForce = 100.0f;

    protected Rigidbody body;
    protected NavMeshAgent agent;

    public void Awake() 
    {
        body = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    public override void TakeDamage( float amount, Destructor damager )
    {
        body.isKinematic = false;
        body.velocity = agent.velocity;

        if ( agent != null )
        {
            agent.enabled = false;
        }

        if ( damager != null )
        {
            Vector3 directionNormal = ( transform.position - damager.transform.position ).normalized;
            body.AddForce( body.mass * knockbackForce * directionNormal );
        }

        body.AddForce( body.mass * knockbackUpwardsForce * Vector3.up );

        base.TakeDamage( amount, damager );
    }

    public void OnCollisionEnter(Collision other)
    {
        if ( agent != null )
        {
            agent.enabled = true;
            agent.velocity = body.velocity;
            body.isKinematic = true;
        }
    }
}
