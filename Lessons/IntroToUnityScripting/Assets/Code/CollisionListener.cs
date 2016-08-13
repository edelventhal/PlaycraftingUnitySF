using UnityEngine;

//when a collision happens, sends messages to any attached CollisionHandlers
public class CollisionListener : MonoBehaviour
{
    public void OnTriggerEnter2D( Collider2D collider )
    {
        DoCollision( collider );
    }
    
    public void OnTriggerStay2D( Collider2D collider )
    {
        DoCollision( collider );
    }
    
    public void OnCollisionEnter2D( Collision2D collision )
    {
        DoCollision( collision.collider );
    }
    
    public void OnCollisionStay2D( Collision2D collision )
    {
        DoCollision( collision.collider );
    }
    
    public void DoCollision( Collider2D collider )
    {
        //this is a useful feature you can do in Unity – it will call any functions named "HandleCollision"
        //that exist on any MonoBehaviour's that are also attached to this GameObject.
        //As a warning – this is a bit inefficient. There are faster but less convenient ways to do this.
        SendMessage( "HandleCollision", collider );
    }
}