using UnityEngine;

//a PhysicsMover is just like a Mover except it uses Unity's built-in physics to move
public class PhysicsMover : MonoBehaviour
{
    //this is how much we accelerate over time. the higher it is, the fast we gain speed
    public float acceleration = 50.0f;
    
    //this is how much force we apply when we jump into the air. the higher it is, the higher we jump
    public float jumpImpulse = 100.0f;
    
    //we need to track whether we're on the ground or not to allow jumping. a "bool" is a boolean
    //value - true or false. So this will either be yes or no to whether we are on the ground.
    private bool isOnGround;
    
    //we need to initialize isOnGround to be false, since we start in the air.
    public void Start()
    {
        isOnGround = false;
    }
    
    //this should look familiar to AddSpeedInDirection from Mover. we're really just naming
    //it the proper thing now.
    public void AccelerateInDirection(Vector2 direction)
    {
        //GetComponent<type>() will give you the component of the given type that is attached to this same object
        GetComponent<Rigidbody2D>().velocity += direction * acceleration * Time.deltaTime;
    }
        
    //applies a single burst of velocity upwards - jump!
    public void Jump()
    {
        //only apply the velocity if we're currently standing on the ground
        if ( isOnGround )
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2( 0.0f, jumpImpulse );
    
            //since we've just jumped, we're no longer on the ground
            isOnGround = false;
        }
    }
    
    //Unity will automatically call this on a MonoBehaviour on the frame that a collision starts
    //between 2 colliders. note that occasionally this doesn't get called - thanks Unity!
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //we collided, so that means we're on the ground
        //note that this is a pretty poor way of doing it, since if we hit our head it would also mean we had
        //jumped... but that's another lesson!
        isOnGround = true;
    }
    
    //Unity will automatically call this on a MonoBehaviour on the frame that a collision ends
    public void OnCollisionExit2D(Collision2D collision)
    {
        //we're not colliding anymore, so we're no longer standing on the ground
        isOnGround = false;
    }
}