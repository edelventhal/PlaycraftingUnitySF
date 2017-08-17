using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    //we need to track whether we're on the ground or not to allow jumping. a "bool" is a boolean
    //value - true or false. So this will either be yes or no to whether we are on the ground.
    public bool isOnGround
    {
        protected set;
        get;
    }

    //we need to initialize isOnGround to be false, since we start in the air.
    public void Start()
    {
        isOnGround = false;
    }

    //Unity will automatically call this on a MonoBehaviour on the frame that a collision starts
    //between 2 colliders. note that occasionally this doesn't get called - thanks Unity!
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //we collided, so that means we're on the ground
        //note that this is a pretty poor way of doing it, since if we hit our head it would also mean we had
        //jumped... maybe you'd fix that by checking collision.normal?
        //this also doesn't work well when we collide with multiple objects, and can fully break.
        //how might we handle multiple collisions? Maybe a list?
        if ( collision.collider.gameObject.layer == 8 )
        {
            isOnGround = true;
        }
    }
    
    //Unity will automatically call this on a MonoBehaviour on the frame that a collision ends
    public void OnCollisionExit2D(Collision2D collision)
    {
        //we're not colliding anymore, so we're no longer standing on the ground
        if ( collision.collider.gameObject.layer == 8 )
        {
            isOnGround = false;
        }
    }
}
