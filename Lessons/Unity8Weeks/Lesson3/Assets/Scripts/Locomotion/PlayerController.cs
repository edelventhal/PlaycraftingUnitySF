using UnityEngine;
using System.Collections;

//this is a controller that listens to keyboard input to move a Mover around.
public class PlayerController : MonoBehaviour
{
    //this is the Mover that we control
    public Mover controlledMover;

    //this is the Jumper we control
    public Jumper controlledJumper;
    
    public void Update()
    {
        //we can use the convenience of Unity's input axes to get direction automatically.
        //bonus! this works with WASD and we can hook it up to work with controllers!
        controlledMover.AccelerateInDirection( new Vector3( Input.GetAxis( "Horizontal" ), 0.0f, 0.0f ) );

        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            controlledJumper.Jump();
        }
    }
}