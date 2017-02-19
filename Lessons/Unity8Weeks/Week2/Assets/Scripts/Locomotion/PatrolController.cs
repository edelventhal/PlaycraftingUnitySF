using UnityEngine;

//The PatrolController will provide simple patrol behavior to a Mover.
//But, it's pretty imperfect – since we go farthest on the very first pass
//(due to having to slow down on subsequent passes), and it allows this
//Mover to jump off cliffs and the like.
//How could we make it smarter to walks to edges? Maybe a raycast?
public class PatrolController : MonoBehaviour
{
    [Tooltip ("The Mover we will control.")]
    public Mover controlledMover;

    [Tooltip ("How long we will patrol in each direction before turning around.")]
    public float patrolTime = 1.0f;

    [Tooltip ("If this is true, then the controller will flip the Mover around if it reaches an edge.")]
    public bool looksAhead = true;

    [Tooltip ("How far we look ahead for the ledge if we want to turn around.")]
    public float lookAheadDistance = 0.5f;

    //how much time we have left before we need to turn around
    private float remainingPatrolTime;

    //the current X direction we're moving: either 1 or -1.
    private float movementDirection;

    public void Start()
    {
        remainingPatrolTime = patrolTime;
        movementDirection = 1.0f;
    }

    public void Update()
    {
        //if it's not safe to walk forwards anymore, stop patrolling in that direction
        if ( !MovingForwardsIsSafe() )
        {
            remainingPatrolTime = 0.0f;
        }

        remainingPatrolTime -= Time.deltaTime;

        //there's still patrol time left, so accelerate in our patrol direction
        if ( remainingPatrolTime > 0.0f )
        {
            controlledMover.AccelerateInDirection( new Vector2( movementDirection, 0.0f ) );
        }
        //we're out of patrol time, so if we've come to rest by now, reverse direction and continue
        else if ( !controlledMover.IsWalking() )
        {
            movementDirection *= -1;

            remainingPatrolTime = patrolTime;
        }
    }

    protected bool MovingForwardsIsSafe()
    {
        //if this thing doesn't look ahead, then it's always safe!
        if ( !looksAhead )
        {
            return true;
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //if we're not going anywhere, it's totally safe to move forwards
        if ( rb.velocity.x == 0.0f )
        {
            return true;
        }

        //this is a fancy way to get a normalized value along a single axis:
        //this is, this will always be 1 or -1... it basically gives us just the sign.
        float directionNormal = rb.velocity.x / Mathf.Abs( rb.velocity.x );

        //transform.right is the direction our right side is facing. It's a normalized vector, meaning
        //it is is ONLY direction, and always has a length (magnitude) of 1.
        GroundDetector groundDetector = controlledMover.GetComponent<GroundDetector>();
        return Physics2D.Raycast( (Vector2) ( transform.position + lookAheadDistance * transform.right * directionNormal ) + groundDetector.colliderCenter,
                                  Vector2.down, groundDetector.collisionRadiusY + 0.1f, groundDetector.onGroundLayerMask );
    }
}
