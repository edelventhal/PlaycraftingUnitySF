
using UnityEngine;

//a simple component that will flip a sprite to match the velocity direction.
[RequireComponent(typeof(Rigidbody2D))]
public class SpriteVelocityFlipper : MonoBehaviour
{
    public bool defaultIsRightFacing = true;

    public SpriteRenderer spriteRenderer;

    public void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //do nothing if we're not moving - stick with the facing we have
        if ( Mathf.Abs( rb.velocity.x ) <= 0.01f )
        {
            return;
        }

        bool flip = rb.velocity.x < 0.0f;

        if ( !defaultIsRightFacing )
        {
            flip = !flip;
        }

        spriteRenderer.flipX = flip;
    }
}
