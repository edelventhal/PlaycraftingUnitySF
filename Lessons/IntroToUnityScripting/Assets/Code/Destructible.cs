using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float hitPoints = 100.0f;
    
    public void ModifyHitPoints( float amount )
    {
        hitPoints += amount;
        
        if ( hitPoints <= 0.0f )
        {
            Die();
        }
    }
    
    public void Die()
    {
        Object.Destroy( gameObject );
    }
}