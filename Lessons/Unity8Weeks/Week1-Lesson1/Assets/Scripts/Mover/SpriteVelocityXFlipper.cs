using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpriteVelocityXFlipper : MonoBehaviour
{
    public SpriteRenderer flippedSpriteRenderer;

    public void Update() 
    {
        flippedSpriteRenderer.flipX = GetComponent<Rigidbody2D>().velocity.x < 0.0f;
    }
}
