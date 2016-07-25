using UnityEngine;
using System.Collections;

//a Mover is a component that can change its position in the unity scene
public class Mover : MonoBehaviour
{
    //how fast do we move, on both the X and Y axis? A "Vector2" is the same as 2 float's, one
    //for the x and one for the y.
    public Vector2 velocity;
    
    // Use this for initialization
    public void Start ()
    {
        
    }
    
    // Update is called once per frame
    public void Update ()
    {
        //so that we can change both the X and the Y positions (and to use more realistic movement)
        //we're going to use a velocity vector to adjust the position. Remember Time.deltaTime!
        transform.position += (Vector3) velocity * Time.deltaTime;
    }
}
