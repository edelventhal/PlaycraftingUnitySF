using UnityEngine;

//a Destructor causes damage to a Destructible when they touch
public class Destructor : MonoBehaviour
{
    public float damageAmount = 1;

    public Destructible destroyedDestructible;

    public virtual void DoDamage( Destructible destructible )
    {
        destructible.TakeDamage( damageAmount );
    }
}