using UnityEngine;
using System.Collections.Generic;

//when a collision happens, sends messages to any attached CollisionHandlers
public class CollisionListener : MonoBehaviour
{
    public bool onlySendOncePerCollision = true;
    
    protected List<Collider2D> activeColliders;
    
    public void Awake()
    {
        activeColliders = new List<Collider2D>();
    }
    
    public void OnTriggerEnter2D( Collider2D collider )
    {
        DoCollision( collider );
    }
    
    public void OnTriggerStay2D( Collider2D collider )
    {
        DoCollision( collider );
    }
    
    public void OnTriggerExit2D( Collider2D collider )
    {
        EndCollision( collider );
    }
    
    public void OnCollisionEnter2D( Collision2D collision )
    {
        DoCollision( collision.collider );
    }
    
    public void OnCollisionStay2D( Collision2D collision )
    {
        DoCollision( collision.collider );
    }
    
    public void OnCollisionExit2D( Collision2D collision )
    {
        EndCollision( collision.collider );
    }
    
    protected void DoCollision( Collider2D collider )
    {
        if ( onlySendOncePerCollision && activeColliders.Contains( collider ) )
        {
            return;
        }
        
        //this is a useful feature you can do in Unity – it will call any functions named "HandleCollision"
        //that exist on any MonoBehaviour's that are also attached to this GameObject.
        //As a warning – this is a bit inefficient. There are faster but less convenient ways to do this.
        SendMessage( "HandleCollision", collider );
        
        activeColliders.Add( collider );
    }
    
    protected void EndCollision( Collider2D collider )
    {
        activeColliders.Remove( collider );
    }
}