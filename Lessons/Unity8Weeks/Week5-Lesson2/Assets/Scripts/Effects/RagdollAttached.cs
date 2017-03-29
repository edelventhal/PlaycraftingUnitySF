using System.Collections.Generic;
using UnityEngine;

//uses Unity's ragdolls to be able to turn on or off a ragdoll effect on demand
public class RagdollAttached : MonoBehaviour
{
    public bool useRootNode = false;

    public bool disableOnStart = true;

    public Rigidbody mainRigidbody;

    public Vector3 appliedEnableForce = new Vector3( 0.0f, 50.0f, 0.0f );

    protected List<Rigidbody> ragdollParts;

    public void Awake() 
    {
        ragdollParts = new List<Rigidbody>();
    }

    public void Start ()
    {
        Rigidbody[] tempParts = GetComponentsInChildren<Rigidbody>();
        for ( int partIndex = 0; partIndex < tempParts.Length; partIndex++ )
        {
            if ( useRootNode || tempParts[partIndex].gameObject != gameObject )
            {
                ragdollParts.Add( tempParts[partIndex] );
            }
        }

        RagdollEnabled = !disableOnStart;
    }

    protected bool _ragdollEnabled;
    public bool RagdollEnabled
    {
        get
        {
            return _ragdollEnabled;
        }
        set
        {
            _ragdollEnabled = value;
            for ( int partIndex = 0; partIndex < ragdollParts.Count; partIndex++ )
            {
                ragdollParts[partIndex].isKinematic = !_ragdollEnabled;
                ragdollParts[partIndex].GetComponent<Collider>().isTrigger = !_ragdollEnabled;
            }
            GetComponent<Animator>().enabled = !_ragdollEnabled;

            if ( !useRootNode )
            {
                GetComponent<Rigidbody>().isKinematic = _ragdollEnabled;
                GetComponent<Collider>().isTrigger = _ragdollEnabled;
            }

            if ( _ragdollEnabled && mainRigidbody != null )
            {
                mainRigidbody.AddForce( appliedEnableForce );
            }
        }
    }
}
