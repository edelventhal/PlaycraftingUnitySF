using UnityEngine;
using System.Collections;

//a Mover is a component that can change its position in the unity scene
public class Mover : MonoBehaviour
{
    // Use this for initialization
    public void Start ()
    {
        
    }
    
    // Update is called once per frame
    public void Update ()
    {
        //since each frame may take up different amounts of time, multiply by Time.deltaTime
        //in order to ensure smooth movement (uniform movement regardless of how long a frame takes)
        //Time.deltaTime is a measure of how long the last frame took in seconds. It will typically
        //be a very small value, somewhere near 1 / 60 (since you have 60 frames a second).
        transform.position += new Vector3( 1.0f * Time.deltaTime, 0.0f, 0.0f );
    }
}
