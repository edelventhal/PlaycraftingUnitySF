using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshPatroller : MonoBehaviour
{
    public Transform[] patrolPoints;

    public float patrolPointChangeDistance = 0.25f;

    protected int pointIndex;

    protected NavMeshAgent agent;

    public void Awake ()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Start ()
    {
        pointIndex = 0;
    }
    
    public void Update ()
    {
        if ( agent.remainingDistance <= patrolPointChangeDistance )
        {
            PatrolTo( (pointIndex + 1) % patrolPoints.Length );
        }
        else
        {
            PatrolToCurrentTarget();
        }
    }

    public void PatrolTo( int newPointIndex )
    {
        pointIndex = newPointIndex;
        PatrolToCurrentTarget();
    }

    public void PatrolToCurrentTarget()
    {
        agent.destination = patrolPoints[pointIndex].position;
    }
}
