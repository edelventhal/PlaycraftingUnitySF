using UnityEngine;
using System.Collections;

//a Mover is a component that can change its position in the unity scene
public class Mover : MonoBehaviour
{
    //how fast do we move at maximum?
    public float speed = 1.0f;
    
    //how much friction do we apply each frame? The higher, the faster we come to a stop.
    public float friction = 4.0f;
    
    //what is our current movement velocity?
    private Vector2 velocity;
    
    // Use this for initialization
    public void Start ()
    {
        velocity = new Vector2( 0.0f, 0.0f );
    }
    
    // Update is called once per frame
    public void Update ()
    {
        //let's add in friction - by reducing the velocity each frame, we know it will
        //eventually come to a stop. We use 1.0f - friction because we want the speed
        //to DECREASE as friction INCREASES.
        velocity *= 1.0f - friction * Time.deltaTime;
        transform.position += (Vector3) velocity * Time.deltaTime;
    }
    
    //this function will instantaneously move us in the direction passed in.
    //we'll be going as fast as our speed.
    public void MoveInDirection(Vector2 direction)
    {
        velocity = direction * speed;
    }
    
    //instead of instantaneously moving us in a direction, this function ADDS to
    //the velocity, which means it only adjusts it, allowing us smoothness.
    public void AddSpeedInDirection(Vector2 direction)
    {
        velocity += direction * speed * Time.deltaTime;
    }
}
