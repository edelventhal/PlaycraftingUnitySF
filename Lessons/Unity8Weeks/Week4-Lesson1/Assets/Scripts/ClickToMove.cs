// ClickToMove.cs
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent agent;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent> ();
    }

    public void Update()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            RaycastHit hitInfo;

            if ( Physics.Raycast( ray.origin, ray.direction, out hitInfo ) )
            {
                agent.destination = hitInfo.point;
            }
        }
    }
}
