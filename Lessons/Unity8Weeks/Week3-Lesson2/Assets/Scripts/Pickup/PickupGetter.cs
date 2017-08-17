using System.Collections.Generic;
using UnityEngine;

//this is something that can get Pickups. Pretty clear, right?
//if something without one of these passes over a Pickup, nothing happens.
//should the trigger handler have been here instead of in the Pickup?
public class PickupGetter : MonoBehaviour
{
    //we'll keep track of every Pickup we've gotten, unless they're consumable
    protected List<Pickup> pickups;

    protected Dictionary<string,int> pickupCountLookup;

    public virtual void Awake()
    {
        pickups = new List<Pickup>();
        pickupCountLookup = new Dictionary<string,int>();
    }

    public virtual void PickUp( Pickup pickup )
    {
        if ( !pickup.isConsumable )
        {
            pickups.Add( pickup );
            
            //increment our count since we just picked one up
            pickupCountLookup[ pickup.id ] = GetPickupCount( pickup.id ) + 1;
        }
    }

    //use a dictionary to make this far more efficient!
    public virtual int GetPickupCount( string pickupId )
    {
        if ( !pickupCountLookup.ContainsKey( pickupId ) )
        {
            return 0;
        }
        return pickupCountLookup[ pickupId ];
    }
}
