using UnityEngine;

public class SetActiveOnTrigger : MonoBehaviour
{
    public bool oneTime = true;

    public GameObject[] setActiveObjects;
    public GameObject[] setInactiveObjects;
    
    public void OnTriggerEnter(Collider other)
    {
        Activate();
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
