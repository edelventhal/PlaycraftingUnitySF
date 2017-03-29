using UnityEngine;

//a FollowCam is a super convenient type of Camera that tries to match a target's position in 
//a nice gradual way. You can change the damping to increase or decrease speed.
//the initial position of the target will affect the resting position of the FollowCam.
[RequireComponent(typeof(Camera))]
public class OverShoulderCam : MonoBehaviour
{
    [Tooltip ("This is the Transform that the Camera will follow.")]
    public Transform target;
    [Tooltip ("The higher the damping, the more slowly we'll follow our target. Damping of 0 snaps to position.")]
    public float damping = 0.05f;

    public float rotationalDamping = 0.05f;
    
    protected Vector3 velocity;

    protected Vector3 rotationalVelocity;
    
    public void LateUpdate()
    {
        if ( target != null )
        {
            //move towards the target
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity,damping);

            //rotate towards the target
            transform.forward = Vector3.SmoothDamp( transform.forward, target.transform.forward, ref rotationalVelocity, rotationalDamping );
        }
    }
}