using UnityEngine;

//a PhysicsMover is just like a Mover except it uses Unity's built-in physics to move
public class PhysicsMover : MonoBehaviour
{
    //this is how much we accelerate over time. the higher it is, the fast we gain speed
    public float acceleration = 50.0f;
    
    //this is how much force we apply when we jump into the air. the higher it is, the higher we jump
    public float jumpImpulse = 10.0f;
    
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
        //apply velocity upwards
        GetComponent<Rigidbody2D>().velocity += new Vector2( 0.0f, jumpImpulse );
    }
}