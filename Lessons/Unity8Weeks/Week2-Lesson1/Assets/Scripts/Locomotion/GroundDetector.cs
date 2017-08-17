using System.Collections.Generic;
using UnityEngine;

//a GroundDetector is capable of telling whether or not they're on the ground
public class GroundDetector : MonoBehaviour
{
    [Tooltip ("These are the layers we collide with for the sake of standing on the ground or not.")]
    public LayerMask onGroundLayerMask;
    
    public bool isOnGround 
    {
        get;
        protected set;
    }

    public float collisionRadiusY
    {
        get;
        protected set;
    }

    //we also need to know the center of our collider so we know where to raycast from
    public Vector2 colliderCenter
    {
        get;
        protected set;
    }

    public virtual void Start()
    {
        BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
        //store the radius of our collider so we know how far to raycast.
        collisionRadiusY = myCollider.size.y / 2.0f;
        //store the center of our collider, and we'll raycast from there.
        colliderCenter = myCollider.offset;
    }

    public virtual void Update() 
    {
        UpdateIsOnGround();
    }

    protected virtual void UpdateIsOnGround()
    {
        //we raycast downward every frame to see if we're very close to the ground.
        //a raycast is like drawing a line and see if it hits anything, or shooting a laser.
        //the first parameter is the ORIGIN of the raycast, which means where the laser shoots from (in this case, the center of our collider).
        //the second parameter is the direction we want to shoot the laser (in this case, always down).
        //the third parameter is how far we want to shoot the laser. Here, we want to shoot as far as we are high, plus a LITTLE more.
        //the fourth parameter is what we want to allow the laser to hit. This way, you can selectively only hit certain things.
        //note that this isn't perfect! We'd probably want to use a BoxCast instead to fix it...
        RaycastHit2D hit = Physics2D.Raycast( (Vector2) transform.position + colliderCenter, Vector2.down, collisionRadiusY + 0.1f, onGroundLayerMask );
        isOnGround = hit.collider != null;

        //this will draw a test line to the scene view. it's a handy way to debug raycasts.
        //I'm using Debug.DrawLine to draw a line that matches where my racyast will go.
        Debug.DrawLine( (Vector2) transform.position + colliderCenter,
                        (Vector2) transform.position + colliderCenter + ( Vector2.down * ( collisionRadiusY + 0.1f ) ),
                        isOnGround ? Color.green : Color.red ); //this ? syntax is like an inline if statement
    }
}
