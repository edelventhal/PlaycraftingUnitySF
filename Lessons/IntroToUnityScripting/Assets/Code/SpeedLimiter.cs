using UnityEngine;

//limits speed on an attached Rigidbody2D
[RequireComponent(typeof(Rigidbody2D))]
public class SpeedLimiter : MonoBehaviour
{
    public float maximumSpeed = Mathf.Infinity;
    
    //when adjusting physics over time, you should always do it in FixedUpdate
    public void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude( GetComponent<Rigidbody2D>().velocity, maximumSpeed );
    }
}