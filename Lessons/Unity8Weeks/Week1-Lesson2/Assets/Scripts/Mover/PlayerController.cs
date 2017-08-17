using UnityEngine;
using System.Collections;

//this is a controller that listens to keyboard input to move a Mover around.
public class PlayerController : MonoBehaviour
{
    //this is the PhysicsMover that we control
    public Mover controlledMover;
    public Jumper controlledJumper;
    
    public void Update()
    {
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            controlledMover.AccelerateInDirection(new Vector3(1.0f, 0.0f));
        }
        
        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            controlledMover.AccelerateInDirection(new Vector3(-1.0f, 0.0f));
        }

        if ( Input.GetKey( KeyCode.Space ) )
        {
            controlledJumper.Jump();
        }
    }
}