using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Jumper))]
public class PeriodicJumpController : MonoBehaviour
{
    public float jumpDelay = 3.0f;

    public void Start ()
    {
        InvokeRepeating( "DoJump", 0.0f, jumpDelay );
    }
    
    public void DoJump()
    {
        GetComponent<Jumper>().Jump();
    }
}
