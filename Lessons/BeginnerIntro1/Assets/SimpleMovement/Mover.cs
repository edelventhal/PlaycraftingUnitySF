using UnityEngine;
using System.Collections;

//a Mover is a component that can change its position in the unity scene
public class Mover : MonoBehaviour
{
    //how fast do we move at maximum?
    public float speed = 1.0f;
    
    //what is our current movement velocity? This is "private" so that we don't expose it in the editor.
    //that's because we only want to change it with MoveInDirection.
    private Vector2 velocity;
    
    // Use this for initialization
    public void Start ()
    {
        velocity = new Vector2( 0.0f, 0.0f );
    }
    
    // Update is called once per frame
    public void Update ()
    {
        //so that we can change both the X and the Y positions (and to use more realistic movement)
        //we're going to use a velocity vector to adjust the position. Remember Time.deltaTime!
        transform.position += (Vector3) velocity * Time.deltaTime;
    }
    
    //this function will instantaneously move us in the direction passed in.
    //we'll be going as fast as our speed.
    public void MoveInDirection(Vector2 direction)
    {
        velocity = direction * speed;
    }
}
