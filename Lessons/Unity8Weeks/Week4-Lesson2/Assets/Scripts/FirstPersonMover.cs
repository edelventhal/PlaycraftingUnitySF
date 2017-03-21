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
        Vector3 delta = new Vector3( Input.GetAxis( "Horizontal" ), 0.0f,  Input.GetAxis( "Vertical" ) );

        if ( delta != Vector3.zero )
        {
            //transform.position += delta * Time.deltaTime * speed;
            GetComponent<NavMeshAgent>().destination = transform.position + delta;
        }
    }
}
