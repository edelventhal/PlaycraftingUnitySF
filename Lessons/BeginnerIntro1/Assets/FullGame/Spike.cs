using UnityEngine;

//a spike causes you to the lose the game when you touch it
public class Spike : MonoBehaviour
{
    //remember, Unity calls this whenever there is a collision
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //this looks confusing. basically, this is how we can get the PhysicsMover that we collided with
        PhysicsMover hitMover = collision.collider.GetComponent<PhysicsMover>();
        
        //it's possible that we don't have any PhysicsMover at all, like if we hit something else
        if ( hitMover != null )
        {
            //this will print some text to the console. this can be very useful for seeing what happens.
            Debug.Log( "The player died!" );
        }
    }
}