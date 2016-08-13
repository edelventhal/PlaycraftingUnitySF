using UnityEngine;

//hurts Destructibles on collisions
public class DamagingCollider : MonoBehaviour
{
    public float damage = 10.0f;
    
    public void OnTriggerEnter2D( Collider2D collider )
    {
        DoCollision( collider );
    }
    
    public void OnTriggerStay2D( Collider2D collider )
    {
        DoCollision( collider );
    }
    
    public void DoCollision( Collider2D collider )
    {
        Destructible destructible = collider.GetComponent<Destructible>();
        if ( destructible != null )
        {
            destructible.ModifyHitPoints( damage * -1.0f );
        }
    }
}