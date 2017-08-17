using UnityEngine;

//this is a simple controller that will tell a Jumper to
//jump periodically.
public class JumpController : MonoBehaviour
{
    public Jumper controlledJumper;

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
            controlledJumper.Jump();

            nextJumpTime = Time.time + jumpDelay;
        }
    }
}
