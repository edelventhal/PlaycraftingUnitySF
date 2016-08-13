using UnityEngine;

public class DamagingCollisionHandler : MonoBehaviour
{
    public float damage = 10.0f;
    
    public void HandleCollision( Collider2D collider )
    {
        Destructible destructible = collider.GetComponent<Destructible>();
        if ( destructible != null )
        {
            destructible.ModifyHitPoints( damage * -1.0f );
        }
    }
}