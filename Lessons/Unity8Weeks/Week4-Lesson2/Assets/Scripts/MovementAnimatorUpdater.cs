using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class MovementAnimatorUpdater : MonoBehaviour
{
    public float walkingSpeedThreshold = 0.3f;
    protected Animator animator;
    protected NavMeshAgent agent;
    protected Rigidbody body;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        body = GetComponent<Rigidbody>();
    }
    
    public void Update()
    {
        animator.SetBool( "jumping", agent.isOnOffMeshLink || !body.isKinematic );
        animator.SetFloat( "speed", agent.velocity.sqrMagnitude / ( agent.speed * agent.speed ) );
    }
}
