using UnityEngine;

public class AnimationOnTrigger : MonoBehaviour
{
    public string triggerName = "dead";

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
            animators[objIndex].SetTrigger( triggerName );
        }

        if ( oneTime )
        {
            Destroy( this );
        }
    }
}
