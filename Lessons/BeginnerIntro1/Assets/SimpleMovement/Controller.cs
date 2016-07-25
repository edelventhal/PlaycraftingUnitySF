using UnityEngine;
using System.Collections;

//a Controller listens for input in order to tell a Mover how to move
public class Controller : MonoBehaviour
{
    //this is the Mover that we will control
    public Mover controlledMover;
    
    public void Update()
    {
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
    }
}