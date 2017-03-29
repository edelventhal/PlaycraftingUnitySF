using UnityEngine;

public class DestructorTrigger : Destructor
{
    public void OnTriggerEnter(Collider other)
    {
        DoCollision( other.GetComponent<Destructible>() );
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        DoCollision( other.GetComponent<Destructible>() );
    }

    protected void DoCollision( Destructible destructible )
    {
        if ( destructible != null )
        {
            DoDamage( destructible );
        }
    }
}
