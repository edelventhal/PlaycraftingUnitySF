using UnityEngine;
using System.Collections;

//a Controller listens for input in order to tell a Mover how to move
public class Controller : MonoBehaviour
{
    //this is the Mover that we will control
    public Mover controlledMover;
    
    public void Update()
    {
        //now, move only when we press the right arrow on the keyboard
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            controlledMover.MoveInDirection(new Vector2(1.0f, 0.0f));
        }
    }
}