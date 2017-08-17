using UnityEngine;

//this is a version of a Destructible that will play death and hurt animations,
//and will delay deleting the prefab until the death animation is complete.
//attach an animator with a boolean "dead" on it, and a "hurt" trigger.
//Note that the death animation (or something else) MUST call MarkReadyForDestroy()
//or the object will never be destroyed.
public class DestructibleAnimated : Destructible
{
    protected bool shouldBeDestroyed = false;
    
    //the animator should call this when we're ready to remove this
    public void MarkReadyForDestroy()
    {
        shouldBeDestroyed = true;
    }
    
    public void Update()
    {
        //if we're dying and either the animator told us that it's time to die, or the animation finished, destroy us
        if ( isDying && shouldBeDestroyed )
        {
            Object.Destroy( gameObject );
        }
    }
    
    //we a overriding ModifyHitPoints from regular Destructible so that
    //we can play animations.
    public override void ModifyHitPoints( float amount )
    {
        if ( amount < 0.0f )
        {
            Animator animator = GetComponent<Animator>();
            if ( animator != null )
            {
                animator.SetTrigger( "hurt" );
            }
        }

        //this calls the regular ModifyHitPoints in Destructible
        base.ModifyHitPoints( amount );
    }

    //when we die, we DON'T always call our base's Die() function,
    //since that would destroy the object. Instead, we play the
    //animation for death by setting the trigger.
    public override void Die()
    {
        if ( isDying )
        {
            return;
        }
        
        
        Animator animator = GetComponent<Animator>();
        if ( animator == null )
        {
            base.Die();
        }
        else
        {
            isDying = true;
            animator.SetBool( "dead", true );
        }
    }
}