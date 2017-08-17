using UnityEngine;

//a pickup is something you can... pick up.
//there are 3 ways of doing this – it's either consumable, hidden, or visible.
//should we have made different components for these behaviors instead?
public class Pickup : MonoBehaviour
{
    [Tooltip ("Consumables get destroyed on pickup, HiddenOnPickup will delete its sprite when picked up, and ShownOnPickup will leave it.")]
    public PickupType type = PickupType.Consumable;

    [Tooltip ("We can use this id to find specific types of items.")]
    public string id = "item";

    //an enum is a nice way to have limited types of things.
    //you can easily turn an enum into an integer (Consumable == 0, HiddenOnPickup == 1),
    //or a string (Consumable == "Consumable"), which is quite handy.
    public enum PickupType
    {
        Consumable = 0,
        HiddenOnPickup,
        ShownOnPickup
    };

    protected bool wasPickedUp;

    public bool isConsumable
    {
        get
        {
            return type == PickupType.Consumable;
        }
    }

    public virtual void PickUp( PickupGetter getter )
    {
        //if we were already picked up, don't allow it again
        if ( wasPickedUp )
        {
            return;
        }

        wasPickedUp = true;
        getter.PickUp( this );

        if ( type == PickupType.Consumable )
        {
            Destroy( gameObject );
        }
        else
        {
            //if we're hidden, we need to destroy the sprite renderers attached.
            //we look in the children in case we have one nested.
            if ( type == PickupType.HiddenOnPickup )
            {
                Destroy( GetComponentInChildren<SpriteRenderer>() );
            }

            //we don't need our collider or physics anymore
            //since Destroy() ignores a null parameter, it's okay to assume we have these components.
            Destroy( GetComponent<Collider2D>() );
            Destroy( GetComponent<Rigidbody2D>() );

            //parent us to the guy who picked us up
            transform.parent = getter.transform;
            transform.localPosition = Vector3.zero;
        }
    }

    public virtual void OnTriggerEnter2D( Collider2D other )
    {
        DoCollision( other );
    }
    public virtual void OnTriggerStay2D( Collider2D other )
    {
        DoCollision( other );
    }

    protected virtual void DoCollision( Collider2D other )
    {
        PickupGetter getter = other.GetComponent<PickupGetter>();

        if ( getter != null )
        {
            PickUp( getter );
        }
    }
}
