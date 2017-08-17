using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshPatroller : MonoBehaviour
{
    public Transform[] patrolPoints;

    public float reachedPointDistance = 1.0f;

    public float giveUpDistance = 50.0f;

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
        if ( agent.remainingDistance <= reachedPointDistance || agent.remainingDistance >= giveUpDistance )
        {
            PatrolToNext();
        }
        else
        {
            agent.destination = patrolPoints[pointIndex].position;
        }
    }

    public void PatrolToNext()
    {
        PatrolTo( (pointIndex + 1) % patrolPoints.Length );
    }

    public void PatrolTo( int newPointIndex )
    {
        pointIndex = newPointIndex;
        agent.destination = patrolPoints[pointIndex].position;
    }
}
