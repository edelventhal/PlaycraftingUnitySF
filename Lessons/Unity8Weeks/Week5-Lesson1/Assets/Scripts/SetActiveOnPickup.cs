using UnityEngine;

public class SetActiveOnPickup : MonoBehaviour
{
    public string pickupId;
    public int requiredPickupCount = 1;

    public bool oneTime = true;

    public PickupGetter trackedGetter;

    public GameObject[] setActiveObjects;
    public GameObject[] setInactiveObjects;
    
    public void Update()
    {
        if ( trackedGetter == null )
        {
            return;
        }

        if ( trackedGetter.GetPickupCount( pickupId ) >= requiredPickupCount )
        {
            Activate();
        }
    }

    protected void Activate()
    {
        for ( int objIndex = 0; objIndex < setActiveObjects.Length; objIndex++ )
        {
            setActiveObjects[objIndex].SetActive(true);
        }

        for ( int objIndex = 0; objIndex < setInactiveObjects.Length; objIndex++ )
        {
            setInactiveObjects[objIndex].SetActive(false);
        }

        if ( oneTime )
        {
            Destroy( this );
        }
    }
}
