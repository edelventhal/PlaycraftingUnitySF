using UnityEngine;

//moves something at a nice smooth oscilating rate using the Sine function
//note that this will force localPosition.z to be 0... can we fix that?
public class SinePositionChanger : MonoBehaviour
{
    public Vector2 movementDistance;

    public float movementPeriod = 1.0f;

    protected Vector3 startPos;

    public void Start ()
    {
        //use the localPosition so that we could move a parent around without disrupting this
        startPos = transform.localPosition;
    }
    
    public void Update ()
    {
        //if you know your trig, sine goes between 0 and 1 each time a multiple of PI radius have passed.
        //so below we'll go through a full period (0->1->0) every movementPeriod seconds.
        float t = Mathf.Sin( ( Time.time / movementPeriod ) * Mathf.PI );

        //since t is between 0 and 1, when we multiply that by our movementDistance (or amplitude, if we're being technical),
        //we'll go between the full distance away (1) and no distance away (0) from where we started.
        transform.localPosition = startPos + (Vector3) ( movementDistance * t );
    }
}
