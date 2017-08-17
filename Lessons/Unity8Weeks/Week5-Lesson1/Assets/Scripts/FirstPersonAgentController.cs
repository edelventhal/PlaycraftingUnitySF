using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class FirstPersonAgentController : MonoBehaviour
{
    public string pickupAnimationName = "pickUp";

    public ControlRelativity controlRelativity;

    public enum ControlRelativity
    {
        World,
        Local,
        Camera
    }

    protected NavMeshAgent agent;
    protected Animator animator;

    public void Awake ()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    
    public void Update ()
    {
        if ( !agent.enabled )
        {
            return;
        }

        if ( animator.GetCurrentAnimatorStateInfo(0).IsName(pickupAnimationName))
        {
            return;
        }

        Vector3 delta = Vector3.zero;

        if ( controlRelativity == ControlRelativity.World )
        {
            delta = new Vector3( Input.GetAxis( "Horizontal" ), 0.0f,  Input.GetAxis( "Vertical" ) );
        }
        else if ( controlRelativity == ControlRelativity.Local )
        {
            delta = GetDeltaFromTransform( transform );
        }
        else if ( controlRelativity == ControlRelativity.Camera )
        {
            delta = GetDeltaFromTransform( Camera.main.transform );
        }

        if ( delta != Vector3.zero )
        {
            agent.destination = transform.position + delta;
        }
    }

    protected Vector3 GetDeltaFromTransform( Transform t )
    {
        return ( t.forward * Input.GetAxis( "Vertical" ) + t.right * Input.GetAxis( "Horizontal" ) ).normalized;
    }
}
