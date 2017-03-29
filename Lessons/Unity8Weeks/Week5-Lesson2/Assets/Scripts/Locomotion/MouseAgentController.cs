// ClickToMove.cs
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class MouseAgentController : MonoBehaviour
{
    protected NavMeshAgent agent;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        if ( !agent.enabled )
        {
            return;
        }

        if( Input.GetMouseButton(0) )
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
