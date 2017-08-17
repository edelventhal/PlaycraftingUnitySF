using UnityEngine;

public class ToggleActiveOnTrigger : MonoBehaviour
{
    public bool oneTime = true;

    public GameObject[] toggleActiveObjects;
    
    public void OnTriggerEnter(Collider other)
    {
        Activate();
    }

    protected void Activate()
    {
        for ( int objIndex = 0; objIndex < toggleActiveObjects.Length; objIndex++ )
        {
            toggleActiveObjects[objIndex].SetActive( !toggleActiveObjects[objIndex].activeSelf );
        }

        if ( oneTime )
        {
            Destroy( this );
        }
    }
}
