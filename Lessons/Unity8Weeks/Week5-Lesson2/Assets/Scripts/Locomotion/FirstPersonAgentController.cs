using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FirstPersonAgentController : MonoBehaviour
{
    public bool relativeMovement = true;

    public string horizontalInputAxis = "Horizontal";

    public string verticalInputAxis = "Vertical";

    public float flyingSpeed = 10.0f;

    protected NavMeshAgent agent;
    protected Rigidbody body;

    public void Awake ()
    {
        agent = GetComponent<NavMeshAgent>();
        body = GetComponent<Rigidbody>();
    }
    
    public void Update ()
    {
        Vector3 delta = new Vector3( Input.GetAxis( horizontalInputAxis ), 0.0f,  Input.GetAxis( verticalInputAxis ) );

        if ( delta != Vector3.zero )
        {
            //use our forward and right to move in a relative direction
            if ( relativeMovement )
            {
                delta = delta.x * transform.right + delta.z * transform.forward;
            }

            if ( agent.enabled )
            {
                UpdateAgent( delta );
            }
            else 
            {
                UpdateRigidbody( delta );
            }
        }
    }

    protected void UpdateAgent( Vector3 delta )
    {
        agent.destination = transform.position + delta;
    }

    protected void UpdateRigidbody( Vector3 delta )
    {
        body.AddForce( delta * Time.deltaTime * flyingSpeed * body.mass );
    }
}
