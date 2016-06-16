using UnityEngine;
using System.Collections;

//STEP 1+
//a Mover is a component that can change its position in the unity scene
public class Mover : MonoBehaviour
{
    //STEP 3
    /*
    //how fast do we move? This is a "float" because it's a floating point number (has decimal places)
    public float speed;
    */
    
    //STEP 4
    /*
    //how fast do we move, on both the X and Y axis? A "Vector2" is the same as 2 float's, one
    //for the x and one for the y.
    public Vector2 velocity;
    */
    
    //STEP 5, 6, 7
    /*
    //how fast do we move at maximum?
    public float speed = 1.0f;
    
    //what is our current movement velocity? This is "private" so that we don't expose it in the editor.
    //that's because we only want to change it with MoveInDirection or AddSpeedInDirection.
    private Vector2 velocity;
    */
    
    //STEP 8+
    /*
    //how fast do we move at maximum?
    public float speed = 1.0f;
    
    //how much friction do we apply each frame? The higher, the faster we come to a stop.
    public float friction = 0.1f;
    
    //what is our current movement velocity?
    private Vector2 velocity;
    */
    
    // Use this for initialization
    public void Start ()
    {
        //STEP 5+
        /*
        velocity = new Vector2( 0.0f, 0.0f );
        */
    }
    
    // Update is called once per frame
    public void Update ()
    {
        //STEP 1
        ///*
        //move our Transform component's position to the right (X-axis) by 0.1 every frame
        transform.position += new Vector3( 0.1f, 0.0f, 0.0f );
        //*/
        
        //STEP 2
        /*
        //since each frame may take up different amounts of time, multiply by Time.deltaTime
        //in order to ensure smooth movement (uniform movement regardless of how long a frame takes)
        //Time.deltaTime is a measure of how long the last frame took in seconds. It will typically
        //be a very small value, somewhere near 1 / 60 (since you have 60 frames a second).
        transform.position += new Vector3( 1.0f * Time.deltaTime, 0.0f, 0.0f );
        */
        
        //STEP 3
        /*
        //use the speed value we declared at the top to change how much we move by.
        //this lets us change the value in the editor to adjust the speed
        transform.position += new Vector3( speed * Time.deltaTime, 0.0f, 0.0f );
        */
        
        //STEP 4, 5, 6, 7
        /*
        //so that we can change both the X and the Y positions (and to use more realistic movement)
        //we're going to use a velocity vector to adjust the position. Remember Time.deltaTime!
        transform.position += (Vector3) velocity * Time.deltaTime;
        */
        
        //STEP 8+
        /*
        //let's add in friction - by reducing the velocity each frame, we know it will
        //eventually come to a stop. We use 1.0f - friction because we want the speed
        //to DECREASE as friction INCREASES.
        velocity *= 1.0f - friction * Time.deltaTime;
        transform.position += (Vector3) velocity * Time.deltaTime;
        */
    }
    
    //STEP 5+
    /*
    //this function will instantaneously move us in the direction passed in.
    //we'll be going as fast as our speed.
    public void MoveInDirection(Vector2 direction)
    {
        velocity = direction * speed;
    }
    */
    
    //STEP 10+
    /*
    //instead of instantaneously moving us in a direction, this function ADDS to
    //the velocity, which means it only adjusts it, allowing us smoothness.
    public void AddSpeedInDirection(Vector2 direction)
    {
        velocity += direction * speed * Time.deltaTime;
    }
    */
}
