using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FirstPersonAgentController : MonoBehaviour
{
    public bool relativeMovement = true;

    public string horizontalInputAxis = "Horizontal";

    public string verticalInputAxis = "Vertical";

    protected NavMeshAgent agent;

    public void Awake ()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    public void Update ()
    {
        if ( !agent.enabled )
        {
            return;
        }

        Vector3 delta = new Vector3( Input.GetAxis( horizontalInputAxis ), 0.0f,  Input.GetAxis( verticalInputAxis ) );

        if ( delta != Vector3.zero )
        {
            //use our forward and right to move in a relative direction
            if ( relativeMovement )
            {
                delta = delta.x * transform.right + delta.z * transform.forward;
            }

            agent.destination = transform.position + delta;
        }
    }
}
