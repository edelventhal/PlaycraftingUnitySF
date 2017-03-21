using UnityEngine;

//a destructible is something that can take damage and be destroyed.
//we can subclass this to different sorts of behaviors when we are
//destroyed or take damage, like play particles or animations.
//destructibles can also be healed, up to their maximum hit points.
public class Destructible : MonoBehaviour
{
    public float maximumHitPoints = 100.0f;
    public float invincibilityTime = 0.5f;

    protected float lastTimeHurt;
    
    public virtual float hitPoints
    {
        get;
        protected set;
    }
    
    public virtual bool isDying
    {
        get;
        protected set;
    }
    
    public virtual void Start()
    {
        hitPoints = maximumHitPoints;

        //we're setting the last time hurt in the past so that we can be hurt immediately
        lastTimeHurt = Time.time - invincibilityTime;
    }
    
    public virtual void TakeDamage( float amount )
    {
        ModifyHitPoints( -amount );
    }

    public virtual void RecoverHitPoints( float amount )
    {
        ModifyHitPoints( amount );
    }
    
    public virtual void ModifyHitPoints( float amount )
    {
        //if we were recently hurt, we can't be hurt again, so do nothing
        if ( Time.time - lastTimeHurt < invincibilityTime && amount < 0.0f )
        {
            return;
        }

        hitPoints += amount;
        hitPoints = Mathf.Min( hitPoints, maximumHitPoints );
        
        if ( hitPoints <= 0.0f )
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if ( isDying )
        {
            return;
        }
        
        isDying = true;
        Object.Destroy( gameObject );
    }
}