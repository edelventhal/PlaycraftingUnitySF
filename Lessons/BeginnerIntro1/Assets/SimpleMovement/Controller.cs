using UnityEngine;
using System.Collections;

//a Controller listens for input in order to tell a Mover how to move
public class Controller : MonoBehaviour
{
    //this is the Mover that we will control
    public Mover controlledMover;
    
    public void Update()
    {
        //we are calling the MoveInDirection function on our controlledMover, telling it to move to the right.
        //notice how the Mover itself handles how fast it moves, the Controller only changes the direction.
        //this is called "encapsulation" – keep logic in relevant places that makes sense and don't let others mess with it.
        controlledMover.MoveInDirection(new Vector2(1.0f, 0.0f));
    }
}