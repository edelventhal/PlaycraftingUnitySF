using UnityEngine;

public class ToggleAnimationOnTrigger : MonoBehaviour
{
    public string boolName = "dead";

    public Animator[] animators;

    public bool oneTime = true;
    
    public void OnTriggerEnter(Collider other)
    {
        Activate();
    }

    protected void Activate()
    {
        for ( int objIndex = 0; objIndex < animators.Length; objIndex++ )
        {
            animators[objIndex].SetBool( boolName, !animators[objIndex].GetBool( boolName ) );
        }

        if ( oneTime )
        {
            Destroy( this );
        }
    }
}
