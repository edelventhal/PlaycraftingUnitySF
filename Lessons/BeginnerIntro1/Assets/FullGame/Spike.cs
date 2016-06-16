using UnityEngine;

//look! something new here! the SceneManager object is part of the UnityEngine.SceneManagement package.
//that means we need to "using" it up here so that we can use it below.
using UnityEngine.SceneManagement;

//STEP 14+
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
            //STEP 14
            /*
            //this will print some text to the console. this can be very useful for seeing what happens.
            Debug.Log( "The player died!" );
            */
            
            //STEP 15
            /*
            //this destroys a Unity object, removing it from the scene. that will cause the hero to disappear.
            //you must destroy the gameObject to destroy the whole object. Destroying the PhysicsMover would
            //just remove that script, and the SpriteRenderer, Transform, etc would all still be around.
            //the gameObject is the collection of all those components.
            Destroy( hitMover.gameObject );
            */
            
            //STEP 16+
            /*
            //this is even better - let's load another scene when we die, so we can show a game over screen.
            SceneManager.LoadScene( "GameOver" );
            */
        }
    }
}