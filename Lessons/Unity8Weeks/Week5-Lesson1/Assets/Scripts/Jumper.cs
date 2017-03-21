using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class Jumper : MonoBehaviour
{
    [Tooltip ("How much vertical force to apply upon jumping.")]
    public float jumpImpulse = 10.0f;

    [Tooltip ("If this is false, then an animation or something else must allow this Jumper to leave the ground before it will actually jump.")]
    public bool canLeaveGroundByDefault = true;

    public LayerMask platformMask;

    protected Rigidbody body;
    protected NavMeshAgent agent;
    protected Animator animator;
    protected bool shouldLeaveGround;

    public void Awake()
    {
        body = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public void Update() 
    {
        //we should move this into a separate controller so we can reuse this code for AI
        if ( Input.GetKeyDown( KeyCode.Space ) && agent.enabled )
        {
            if ( animator != null )
            {
                animator.SetTrigger( "jump" );
            }

            if ( canLeaveGroundByDefault )
            {
                Jump();
            }
        }

        if ( !canLeaveGroundByDefault && shouldLeaveGround )
        {
            Jump();
            shouldLeaveGround = false;
        }
    }
    
    public void Jump()
    {
        body.isKinematic = false;
        body.velocity = agent.velocity;
        agent.enabled = false;
        body.AddForce( Vector3.up * jumpImpulse );
    }

    public void Land()
    {
        agent.enabled = true;
        agent.velocity = body.velocity;
        body.isKinematic = true;
    }

    public void AllowLeavingGround()
    {
        shouldLeaveGround = true;
    }

    public void OnCollisionEnter(Collision other)
    {
        DoCollision(other);
    }

    public void OnCollisionStay(Collision other)
    {
        DoCollision(other);
    }

    protected void DoCollision(Collision other)
    {
        if ( body.velocity.y <= 0.0f )
        {
            Land();
        }
    }
}
