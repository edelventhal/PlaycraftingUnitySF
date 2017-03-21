using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GirlAnimations : MonoBehaviour
{
    public bool wonGameBra = false;

    public bool diedBra = false;

    protected Animator animator;

    public void Awake ()
    {
        animator = GetComponent<Animator>();
    }

    public void Start() 
    {
        animator.SetBool( "wonGame", false );
    }
    
    public void Update ()
    {
        animator.SetBool( "wonGame", wonGameBra );

        if ( diedBra )
        {
            animator.SetTrigger( "gotShot" );
        }
    }
}
