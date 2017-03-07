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

    public Vector2 collisionSize
    {
        get;
        protected set;
    }

    //we're leaving this here for "backwards compatibility"
    //each time you adjust an existing feature, you have a choice: either go back and
    //change every reference to that code, or make your new code in a way that doesn't 
    //break your old code's functionality. In this case, we do the latter.
    public float collisionRadiusY
    {
        get
        {
            return collisionSize.y / 2.0f;
        }
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
        //store the size of our collider so we know how far to raycast.
        collisionSize = myCollider.size;
        //store the center of our collider, and we'll raycast from there.
        colliderCenter = myCollider.offset;
    }

    public virtual void Update() 
    {
        UpdateIsOnGround();
    }

    protected virtual void UpdateIsOnGround()
    {
        //we're using a smaller collision box here so that we don't set on ground from a sideways collision
        Vector2 usedCollisionSize = new Vector2( collisionSize.x * 0.9f, collisionSize.y );

        //we boxcast downward every frame to see if we're very close to the ground.
        //a boxcast is like dragging a box over a distance and seeing if it hits anything.
        //the first parameter is the ORIGIN of the boxcast, which means where the center of the box starts (in this case, the center of our collider).
        //the second parameter is how big the box is before it is dragged over a distance.
        //the third parameter is the angle the box is turned, in degrees. Since our collider can't rotate, we won't allow it here.
        //the fourth parameter is the direction we want to drag the box (in this case, always down).
        //the fifth parameter is how far we want to drag the box. Since the box already represents our collision area, we just want to drag a tiny bit.
        //the sixth parameter is what we want to allow the laser to hit. This way, you can selectively only hit certain things.
        //now that we have the BoxCast, it should very closely match how our actual collider is represented.
        isOnGround = Physics2D.BoxCast( (Vector2) transform.position + colliderCenter, usedCollisionSize, 0.0f, Vector2.down, 0.1f, onGroundLayerMask );

        //we're going to draw 4 test lines this time to show the entire box.
        //there are other ways of doing this, but they require an editor class, which is quite complicated!
        Color color = isOnGround ? Color.green : Color.red;
        Vector2 center = (Vector2) transform.position + colliderCenter;
        Vector2 radius = usedCollisionSize / 2.0f;
        Vector2 topLeft = center + new Vector2( -radius.x, radius.y );
        Vector2 topRight = center + radius;
        Vector2 bottomRight = center + new Vector2( radius.x, -radius.y ) + Vector2.down * 0.1f;
        Vector2 bottomLeft = center - radius + Vector2.down * 0.1f;
        Debug.DrawLine( topLeft, topRight, color );
        Debug.DrawLine( topRight, bottomRight, color );
        Debug.DrawLine( bottomRight, bottomLeft, color );
        Debug.DrawLine( bottomLeft, topLeft, color );
    }
}
