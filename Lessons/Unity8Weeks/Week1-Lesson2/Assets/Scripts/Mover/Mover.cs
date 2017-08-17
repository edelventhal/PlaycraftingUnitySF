using UnityEngine;

//a Mover is something that can move around along the X axis.
[RequireComponent(typeof(GroundDetector))]
public class Mover : MonoBehaviour
{
    [Tooltip ("How much we accelerate over time on the ground. the higher it is, the fast we gain speed.")]
    public float acceleration = 50.0f;

    [Tooltip ("How much we accelerate when we're in the air.")]
    public float aerialAcceleration = 10.0f;
    
    [Tooltip ("How fast we can go at the very maximum.")]
    public float maximumSpeed = 20.0f;

    [Tooltip ("When our X velocity is lower than this, we are standing. This is mostly for aesthetic reasons like animations.")]
    public float minimumWalkSpeed = 0.1f;
    
    //if this Mover has an Animator attached, we can play animations as we go.
    protected Animator animator;

    //this is the GroundDetector that we use to tell whether we're on the ground or not 
    protected GroundDetector groundDetector;

    //we need to initialize isOnGround to be false, since we start in the air.
    public void Start()
    {
        animator = GetComponent<Animator>();
        groundDetector = GetComponent<GroundDetector>();
    }

    public void Update()
    {
        if ( animator != null )
        {
            //tell the animator if we're walking or not
            animator.SetBool( "walking", IsWalking() );
        }
    }
    
    //this tells our Rigidbody to accelerate in a given direction, using our acceleration or
    //aerialAcceleration values, depending on if we're in the air or not.
    public void AccelerateInDirection(Vector2 direction)
    {
        float accel = acceleration;
        if ( !groundDetector.isOnGround )
        {
            accel = aerialAcceleration;
        }

        //GetComponent<type>() will give you the component of the given type that is attached to this same object
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 newVelocity = rb.velocity + direction * accel * Time.deltaTime;
        newVelocity.x = Mathf.Clamp( newVelocity.x, -maximumSpeed, maximumSpeed );
        rb.velocity = newVelocity;
    }

    //this is convenient for controllers to know. we're walking if we have any x velocity.
    public bool IsWalking()
    {
        return Mathf.Abs( GetComponent<Rigidbody2D>().velocity.x ) >= minimumWalkSpeed;
    }
}