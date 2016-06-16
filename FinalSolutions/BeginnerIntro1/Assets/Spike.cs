using UnityEngine;

//look! something new here! the SceneManager object is part of the UnityEngine.SceneManagement package.
//that means we need to "using" it up here so that we can use it below.
using UnityEngine.SceneManagement;

//a spike causes you to the lose the game when you touch it
public class Spike : MonoBehaviour
{
    //remember, Unity calls this whenever there is a collision
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //this looks confusing. let's break down what it does:
        //we're creating a new variable that is a PhysicsMover, and naming it "hitMover"
        //we're setting that variable to:
        //the PhysicsMover that is part of
        //the collider that was the other object in
        //this collision
        //basically, this is how we can get the PhysicsMover that we collided with
        PhysicsMover hitMover = collision.collider.GetComponent<PhysicsMover>();
        
        //it's possible that we don't have any PhysicsMover at all. This would happen, for example,
        //if we collided with the ground (the ground has no PhysicsMover attached to it).
        //so, this code checks to make sure that hitMover is NOT EQUALS TO (!=) "null".
        //null essentially means "nothing". So we're checking to make sure it's something.
        if ( hitMover != null )
        {
            //let's load another scene when we die, so we can show a game over screen.
            SceneManager.LoadScene( "GameOver" );
        }
    }
}