using UnityEngine;

//forwards collision and trigger events to a target object
public class CollisionForwarder : MonoBehaviour
{
    public GameObject target;

    public void OnTriggerEnter2D( Collider2D other )
    {
        target.SendMessage( "OnTriggerEnter2D", other );
    }
    public void OnTriggerStay2D( Collider2D other )
    {
        target.SendMessage( "OnTriggerStay2D", other );
    }

    public void OnTriggerExit2D( Collider2D other )
    {
        target.SendMessage( "OnTriggerExit2D", other );
    }

    public void OnCollisionEnter2D( Collision2D other )
    {
        target.SendMessage( "OnCollisionEnter2D", other );
    }
    public void OnCollisionStay2D( Collision2D other )
    {
        target.SendMessage( "OnCollisionStay2D", other );
    }

    public void OnCollisionExit2D( Collision2D other )
    {
        target.SendMessage( "OnCollisionExit2D", other );
    }

    public void OnTriggerEnter( Collider other )
    {
        target.SendMessage( "OnTriggerEnter", other );
    }
    public void OnTriggerStay( Collider other )
    {
        target.SendMessage( "OnTriggerStay", other );
    }

    public void OnTriggerExit( Collider other )
    {
        target.SendMessage( "OnTriggerExit", other );
    }

    public void OnCollisionEnter( Collision other )
    {
        target.SendMessage( "OnCollisionEnter", other );
    }
    public void OnCollisionStay( Collision other )
    {
        target.SendMessage( "OnCollisionStay", other );
    }

    public void OnCollisionExit( Collision other )
    {
        target.SendMessage( "OnCollisionExit", other );
    }
}
