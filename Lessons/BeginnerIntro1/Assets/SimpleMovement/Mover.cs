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
        //move our Transform component's position to the right (X-axis) by 0.1 every frame
        transform.position += new Vector3( 0.1f, 0.0f, 0.0f );
    }
}
