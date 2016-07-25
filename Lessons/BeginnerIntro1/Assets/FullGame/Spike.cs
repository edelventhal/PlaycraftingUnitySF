using UnityEngine;
using UnityEngine.SceneManagement;

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
            //this is even better - let's load another scene when we die, so we can show a game over screen.
            SceneManager.LoadScene( "GameOver" );
        }
    }
}