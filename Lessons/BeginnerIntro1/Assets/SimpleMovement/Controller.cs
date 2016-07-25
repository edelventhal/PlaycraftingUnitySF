using UnityEngine;
using System.Collections;

//a Controller listens for input in order to tell a Mover how to move
public class Controller : MonoBehaviour
{
    //this is the Mover that we will control
    public Mover controlledMover;
    
    public void Update()
    {
        //instead of immediately setting the position, let's change it over time
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            controlledMover.AddSpeedInDirection(new Vector2(1.0f, 0.0f));
        }
        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            controlledMover.AddSpeedInDirection(new Vector2(-1.0f, 0.0f));
        }
        if ( Input.GetKey( KeyCode.UpArrow ) )
        {
            controlledMover.AddSpeedInDirection(new Vector2(0.0f, 1.0f));
        }
        if ( Input.GetKey( KeyCode.DownArrow ) )
        {
            controlledMover.AddSpeedInDirection(new Vector2(0.0f, -1.0f));
        }
    }
}