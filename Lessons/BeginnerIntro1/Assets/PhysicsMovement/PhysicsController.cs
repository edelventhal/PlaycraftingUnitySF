using UnityEngine;
using System.Collections;

//just like the Controller, except this moves a PhysicsMover instead
public class PhysicsController : MonoBehaviour
{
    //this is the PhysicsMover that we control
    public PhysicsMover controlledMover;
    
    public void Update()
    {
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
    }
}