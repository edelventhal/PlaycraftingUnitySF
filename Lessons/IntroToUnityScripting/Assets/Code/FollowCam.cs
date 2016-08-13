using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float damping = 0.05f;
    
    protected Vector3 velocity;
    
    public void Update()
    {
        Vector3 targetPos = target.transform.position;
        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity,damping);
    }
}