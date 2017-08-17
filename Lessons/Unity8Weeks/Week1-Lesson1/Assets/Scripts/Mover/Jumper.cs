using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
public class Jumper : MonoBehaviour
{
    [Tooltip ("How much force we apply when we jump into the air. the higher it is, the higher we jump.")]
    public float jumpImpulse = 10.0f;
    public int maximumAirJumpCount = 1;

    public float jumpDelay = 0.5f;

    private int airJumpCount;
    private float lastTimeJumped;

    private GroundDetector groundDetector;

    public void Awake() 
    {
        groundDetector = GetComponent<GroundDetector>();
    }

    //applies a single burst of velocity upwards - jump!
    public void Jump()
    {
        float timeSinceJumped = Time.time - lastTimeJumped;

        //only apply the velocity if we're currently standing on the ground
        if ( timeSinceJumped >= jumpDelay && ( groundDetector.isOnGround || airJumpCount < maximumAirJumpCount ) )
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2( 0.0f, jumpImpulse );

            if ( groundDetector.isOnGround )
            {
                airJumpCount = 0;
            }
            else 
            {
                airJumpCount++;
            }

            lastTimeJumped = Time.time;
        }
    }
}
