using UnityEngine;

public class BouncingCollisionHandler : MonoBehaviour
{
    [Tooltip("How much force to apply upon collision. This is multiplied by the mass of the colliding object.")]
    public float bounceForce = 100.0f;
    
    [Tooltip("If true, anything colliding with this will bounce in the direction of the angle between that object and this.")]
    public bool bouncesFromNormal = true;
    
    [Tooltip("The bounce is applied in this normalized direction. Can be combined with bouncesFromNormal to apply force twice.")]
    public Vector3 bounceDirection = Vector3.zero;
    
    public void Start()
    {
        bounceDirection = bounceDirection.normalized;
    }
    
    public void HandleCollision( Collider2D collider )
    {
        Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
        if ( rb != null )
        {
            if ( bouncesFromNormal )
            {
                rb.AddForce( ( rb.transform.position - transform.position ).normalized * bounceForce * rb.mass );
            }
            
            if ( bounceDirection != Vector3.zero )
            {
                rb.AddForce( bounceDirection * bounceForce * rb.mass );
            }
        }
    }
}