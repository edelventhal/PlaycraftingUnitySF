using UnityEngine;
using System.Collections;

//just like the Controller, except this moves a PhysicsMover instead
public class PhysicsController : MonoBehaviour
{
    //this is the PhysicsMover that we control
    public PhysicsMover controlledMover;
    
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
        //instead of being able to move up and down, let's make it so that we use the space bar to jump!
        if ( Input.GetKey( KeyCode.Space ) )
        {
            controlledMover.Jump();
        }
    }
}