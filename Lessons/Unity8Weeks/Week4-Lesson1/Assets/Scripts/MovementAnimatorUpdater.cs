using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class MovementAnimatorUpdater : MonoBehaviour
{
    public float walkingSpeedThreshold = 0.3f;
    protected Animator animator;
    protected NavMeshAgent agent;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    
    public void Update()
    {
        animator.SetBool( "walking", ( agent.velocity.sqrMagnitude >= walkingSpeedThreshold * walkingSpeedThreshold ) );
        animator.SetBool( "jumping", agent.isOnOffMeshLink );
        animator.SetFloat( "speed", agent.velocity.sqrMagnitude / ( agent.speed * agent.speed ) );
    }
}
