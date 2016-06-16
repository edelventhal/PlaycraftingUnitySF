using UnityEngine;
using System.Collections;

//STEP 6+
//a Controller listens for input in order to tell a Mover how to move
public class Controller : MonoBehaviour
{
    //this is the Mover that we will control
    public Mover controlledMover;
    
    public void Update()
    {
        //STEP 6
        /*
        //we are calling the MoveInDirection function on our controlledMover, telling it to move to the right.
        //notice how the Mover itself handles how fast it moves, the Controller only changes the direction.
        //this is called "encapsulation" – keep logic in relevant places that makes sense and don't let others mess with it.
        controlledMover.MoveInDirection(new Vector2(1.0f, 0.0f));
        */
        
        //STEP 7, 8
        /*
        //now, move only when we press the right arrow on the keyboard
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            controlledMover.MoveInDirection(new Vector2(1.0f, 0.0f));
        }
        */
        
        //STEP 9
        /*
        //we do the same thing for every direction. The directions are determined by
        //the same way a graph in math works - really Unity's scene is one big graph.
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            controlledMover.MoveInDirection(new Vector2(1.0f, 0.0f));
        }
        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            controlledMover.MoveInDirection(new Vector2(-1.0f, 0.0f));
        }
        if ( Input.GetKey( KeyCode.UpArrow ) )
        {
            controlledMover.MoveInDirection(new Vector2(0.0f, 1.0f));
        }
        if ( Input.GetKey( KeyCode.DownArrow ) )
        {
            controlledMover.MoveInDirection(new Vector2(0.0f, -1.0f));
        }
        */
        
        //STEP 10+
        /*
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
        */
    }
}