using UnityEngine;

//this is a simple controller that will tell a Mover to
//jump periodically.
public class JumpController : MonoBehaviour
{
    public Mover controlledMover;

    public float jumpDelay = 1.0f;

    private float nextJumpTime;

    public void Start()
    {
        nextJumpTime = 0.0f;
    }


    public void Update()
    {
        if ( Time.time >= nextJumpTime )
        {
            controlledMover.Jump();

            nextJumpTime = Time.time + jumpDelay;
        }
    }
}
