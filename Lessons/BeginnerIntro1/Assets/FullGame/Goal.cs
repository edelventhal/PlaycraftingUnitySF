using UnityEngine;
using UnityEngine.SceneManagement;

//a goal causes you to the win the game when you touch it
public class Goal : MonoBehaviour
{
    //remember, Unity calls this whenever there is a collision
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //get the player we hit
        PhysicsMover hitMover = collision.collider.GetComponent<PhysicsMover>();
        
        //make sure we actually hit one
        if ( hitMover != null )
        {
            //win the game
            SceneManager.LoadScene( "WonGame" );
        }
    }
}