using UnityEngine;

//RequireComponent is a cool Unity thing where it can block you from trying
//to add a Jumper component unless you have a GroundDetector already on that GameObject.
[RequireComponent(typeof(GroundDetector))]
//a Jumper can jump when they're on the ground
public class Jumper : MonoBehaviour
{
    [Tooltip ("How much force we apply when we jump into the air. the higher it is, the higher we jump.")]
    public float jumpImpulse = 10.0f;

    [Tooltip ("This is how long of a delay we must wait before we can jump again.")]
    public float jumpDelay = 0.25f;
    
    //if the Jumper has an Animator attached, we can play animations as we go.
    protected Animator animator;

    //this is the GroundDetector that we use to tell whether we're on the ground or not 
    protected GroundDetector groundDetector;

    //we need to store the last time we jumped so that we can potentially block rapid-fire jumping
    protected float lastTimeJumped;

    //we need to initialize isOnGround to be false, since we start in the air.
    public void Start()
    {
        animator = GetComponent<Animator>();
        groundDetector = GetComponent<GroundDetector>();
        lastTimeJumped = Time.time - jumpDelay; //we want to be able to jump immediately
    }

    public void Update()
    {
        //if we have an Animator, tell it how to animate
        if ( animator != null )
        {
            //tell the animator if we're jumping or not
            //we could put this in the ground detector, but that doesn't make a ton of sense, does it?
            animator.SetBool( "jumping", !groundDetector.isOnGround );
        }
    }
    
    //applies a single burst of velocity upwards - jump!
    public void Jump()
    {
        float timeSinceJumped = Time.time - lastTimeJumped;

        //only apply the velocity if we're currently standing on the ground and haven't jumped recently
        if ( groundDetector.isOnGround && timeSinceJumped > jumpDelay )
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2( 0.0f, jumpImpulse );
            lastTimeJumped = Time.time;
        }
    }
}