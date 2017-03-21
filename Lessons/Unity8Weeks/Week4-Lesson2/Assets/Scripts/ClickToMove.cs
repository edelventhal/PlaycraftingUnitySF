// ClickToMove.cs
using UnityEngine;

[RequireComponent (typeof (UnityEngine.AI.NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    RaycastHit hitInfo = new RaycastHit();
    UnityEngine.AI.NavMeshAgent agent;

    public void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
    }

    public void Update()
    {
        if( Input.GetMouseButton(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );

            if ( Physics.Raycast( ray.origin, ray.direction, out hitInfo ) )
            {
                agent.destination = hitInfo.point;
            }
        }
    }
}
