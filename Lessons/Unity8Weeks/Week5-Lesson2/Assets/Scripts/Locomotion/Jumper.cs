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
    protected RagdollAttached ragdoll;
    protected bool shouldLeaveGround;

    protected LandingResponder[] landingResponders;

    public void Awake()
    {
        body = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        ragdoll = GetComponent<RagdollAttached>();
        landingResponders = GetComponents<LandingResponder>();
    }

    public void Update() 
    {
        if ( !canLeaveGroundByDefault && shouldLeaveGround )
        {
            Jump();
        }
    }
    
    public bool CanJump
    {
        get
        {
            return agent.enabled && ( ragdoll == null || !ragdoll.RagdollEnabled );
        }
    }

    public void Jump()
    {
        if ( !CanJump )
        {
            return;
        }

        //we haven't actually started jumping yet, so begin playing the animation
        if ( !canLeaveGroundByDefault && !shouldLeaveGround && animator != null )
        {
            animator.SetTrigger( "jump" );
            return;
        }

        //otherwise, actually jump
        body.isKinematic = false;
        body.velocity = agent.velocity;
        agent.enabled = false;
        body.AddForce( Vector3.up * jumpImpulse );

        shouldLeaveGround = false;

        for ( int responderIndex = 0; responderIndex < landingResponders.Length; responderIndex++ )
        {
            landingResponders[ responderIndex ].Jumped();
        }
    }

    public void Land()
    {
        bool canLand = true;
        for ( int responderIndex = 0; responderIndex < landingResponders.Length; responderIndex++ )
        {
            landingResponders[ responderIndex ].Landed();

            if ( !landingResponders[ responderIndex ].CanLand() )
            {
                canLand = false;
                break;
            }
        }

        if ( !canLand )
        {
            return;
        }

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
