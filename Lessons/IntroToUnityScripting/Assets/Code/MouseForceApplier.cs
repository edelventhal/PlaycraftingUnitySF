using UnityEngine;

public class MouseForceApplier : MonoBehaviour
{
    [Tooltip("This amount of force is applied in each dimension towards where the mouse is clicking.")]
    public Vector2 appliedForce = new Vector2( 50.0f, 0.0f );
    
    [Tooltip("The force will be applied to this target object.")]
    public Rigidbody2D target;
    
    //remember, physics will be applied from here, so we'll use FixedUpdate
    public void FixedUpdate()
    {
        if ( target != null )
        {
            if ( Input.GetMouseButton( 0 ) )
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
                Vector2 forceDirection = ( (Vector2) ( mouseWorldPos - target.transform.position ) ).normalized;
                Vector2 forceAmount = Vector2.Scale( appliedForce, forceDirection );
            
                //we must multiply by fixedDeltaTime since this is being applied every frame
                target.AddForce( forceAmount * target.mass * Time.fixedDeltaTime );
            }
        }
    }
}