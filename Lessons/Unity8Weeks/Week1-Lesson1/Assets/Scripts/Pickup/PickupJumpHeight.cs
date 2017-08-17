using UnityEngine;

//this is a Pickup that rewards health when picked up.
public class PickupJumpHeight : Pickup
{
    public float jumpImpulseIncrease = 3.0f;

    public override void PickUp( PickupGetter getter )
    {
        //first, give health back, if applicable
        Jumper jumper = getter.GetComponent<Jumper>();
        if ( jumper != null )
        {
            jumper.jumpImpulse += jumpImpulseIncrease;
        }

        //then, do our default behavior
        base.PickUp( getter );
    }
}
