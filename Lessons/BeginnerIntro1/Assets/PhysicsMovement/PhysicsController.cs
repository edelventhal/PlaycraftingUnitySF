using UnityEngine;
using System.Collections;

//STEP 11+
//just like the Controller, except this moves a PhysicsMover instead
public class PhysicsController : MonoBehaviour
{
    //this is the PhysicsMover that we control
    public PhysicsMover controlledMover;
    
    public void Update()
    {
        //STEP 11
        /*
        //this is totally the same as the Controller code!
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            controlledMover.AccelerateInDirection(new Vector2(1.0f, 0.0f));
        }
        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            controlledMover.AccelerateInDirection(new Vector2(-1.0f, 0.0f));
        }
        if ( Input.GetKey( KeyCode.UpArrow ) )
        {
            controlledMover.AccelerateInDirection(new Vector2(0.0f, 1.0f));
        }
        if ( Input.GetKey( KeyCode.DownArrow ) )
        {
            controlledMover.AccelerateInDirection(new Vector2(0.0f, -1.0f));
        }
        */
        
        //STEP 12+
        /*
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            controlledMover.AccelerateInDirection(new Vector3(1.0f, 0.0f));
        }
        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            controlledMover.AccelerateInDirection(new Vector3(-1.0f, 0.0f));
        }
        //instead of being able to move up and down, let's make it so that we use the space bar to jump!
        if ( Input.GetKey( KeyCode.Space ) )
        {
            controlledMover.Jump();
        }
        */
    }
}