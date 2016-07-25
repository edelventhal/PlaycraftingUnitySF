using UnityEngine;
using System.Collections;

//a Mover is a component that can change its position in the unity scene
public class Mover : MonoBehaviour
{
    //how fast do we move? This is a "float" because it's a floating point number (has decimals)
    public float speed;
    
    // Use this for initialization
    public void Start ()
    {
        
    }
    
    // Update is called once per frame
    public void Update ()
    {
        //use the speed value we declared at the top to change how much we move by.
        //this lets us change the value in the editor to adjust the speed
        transform.position += new Vector3( speed * Time.deltaTime, 0.0f, 0.0f );
    }
}
