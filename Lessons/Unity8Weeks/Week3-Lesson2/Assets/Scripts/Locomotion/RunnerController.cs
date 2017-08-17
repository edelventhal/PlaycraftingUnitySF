using UnityEngine;

//tells a Mover to keep on runnin'!
public class RunnerController : MonoBehaviour
{
    public Mover controlledMover;

    [Tooltip ("The controlledMover will always move in this direction.")]
    public Vector2 targetDirection;


    public void Update()
    {
        controlledMover.AccelerateInDirection( targetDirection );
    }
}
