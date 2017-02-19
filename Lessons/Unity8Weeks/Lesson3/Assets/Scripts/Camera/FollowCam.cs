using UnityEngine;

//a FollowCam is a super convenient type of Camera that tries to match a target's position in 
//a nice gradual way. You can change the damping to increase or decrease speed.
//the initial position of the target will affect the resting position of the FollowCam.
[RequireComponent(typeof(Camera))]
public class FollowCam : MonoBehaviour
{
    [Tooltip ("This is the Transform that the Camera will follow.")]
    public Transform target;
    [Tooltip ("The higher the damping, the more slowly we'll follow our target. Damping of 0 snaps to position.")]
    public float damping = 0.05f;
    
    protected Vector3 velocity;
    protected Vector3 offset;
    
    public void Start()
    {
        if ( target != null )
        {
            offset = transform.position - target.transform.position;
        }
    }
    
    public void LateUpdate()
    {
        if ( target != null )
        {
            Vector3 targetPos = target.transform.position + offset;
            targetPos.z = transform.position.z;

            //SmoothDamp is a cool Unity function that uses a velocity to gradually change towards a target value.
            //the "ref" keyword means we are "passing by reference" which is a fancy way of saying that SmoothDamp
            //can modify that exact variable (the "velocity" variable) instead of a copy of it.
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity,damping);
        }
    }
}