using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirstPersonMover : MonoBehaviour
{
    public float speed = 10.0f;

    public void Start ()
    {
        
    }
    
    public void Update ()
    {
        Vector3 delta = transform.forward * Input.GetAxis( "Vertical" ) + transform.right * Input.GetAxis( "Horizontal" );

        if ( GetComponent<NavMeshAgent>().enabled )
        {
            if ( delta != Vector3.zero )
            {
                //transform.position += delta * Time.deltaTime * speed;
                GetComponent<NavMeshAgent>().destination = transform.position + delta;
            }
            else 
            {
                GetComponent<NavMeshAgent>().destination = transform.position;
            }
        }
    }
}
