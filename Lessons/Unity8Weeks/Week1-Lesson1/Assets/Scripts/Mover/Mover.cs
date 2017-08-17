using UnityEngine;

//a PhysicsMover is just like a Mover except it uses Unity's built-in physics to move
public class Mover : MonoBehaviour
{
    [Tooltip ("How much we accelerate over time on the ground. the higher it is, the fast we gain speed.")]
    public float acceleration = 50.0f;
    
    [Tooltip ("How fast we can go at the very maximum.")]
    public float maximumSpeed = 20.0f;

    [Tooltip ("When our X velocity is lower than this, we are standing. This is mostly for aesthetic reasons like animations.")]
    public float minimumWalkSpeed = 0.1f;

    
    //this tells our Rigidbody to accelerate in a given direction, using our acceleration or
    //aerialAcceleration values, depending on if we're in the air or not.
    public void AccelerateInDirection(Vector2 direction)
    {
        //GetComponent<type>() will give you the component of the given type that is attached to this same object
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 newVelocity = rb.velocity + direction * acceleration * Time.deltaTime;
        newVelocity.x = Mathf.Clamp( newVelocity.x, -maximumSpeed, maximumSpeed );
        rb.velocity = newVelocity;
    }

    //this is convenient for controllers to know. we're walking if we have any x velocity.
    public bool IsWalking()
    {
        return Mathf.Abs( GetComponent<Rigidbody2D>().velocity.x ) >= minimumWalkSpeed;
    }
}