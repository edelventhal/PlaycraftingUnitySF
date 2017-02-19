using UnityEngine;

//this is a Pickup that rewards health when picked up.
public class PickupHealth : Pickup
{
    public float recoveryAmount = 1.0f;

    public override void PickUp( PickupGetter getter )
    {
        //first, give health back, if applicable
        Destructible destructible = getter.GetComponent<Destructible>();
        if ( destructible != null )
        {
            destructible.RecoverHitPoints( recoveryAmount );
        }

        //then, do our default behavior
        base.PickUp( getter );
    }
}
