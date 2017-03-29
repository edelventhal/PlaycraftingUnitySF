using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Ragdoll : MonoBehaviour
{
    [Tooltip ("Since the ragdoll parts can move far away from the actual physics, set this so we can track the proper location.")]
    public Rigidbody rootRigidbody;

    [Tooltip ("When our root rigidbody hits the ground, apply this much force upwards. Make sure to add a CollisionForwarder to the rootRigidbody.")]
    public float upwardsForceAppliedOnCollision = 100.0f;

    [Tooltip ("When our root rigidbody hits the ground, apply this much force opposite the collision surface. Make sure to add a CollisionForwarder to the rootRigidbody.")]
    public float tangentialForceAppliedOnCollision = 100.0f;

    [Tooltip ("We need to collide with an object in this mask in order to apply collision forces.")]
    public LayerMask collisionMask;

    [Tooltip ("If this is set, the camera will be set to watch this target upon creation. Otherwise, it'll want the rootRigidbody.")]
    public Transform cameraTarget;

    [Tooltip ("How long it takes to restore to the original position of the source, once we're in a valid location to do so.")]
    public float restorePositionTime = 0.5f;

    protected Transform sourceCameraTarget;

    protected Dictionary<string,TransformData> startTransformData;
    protected Dictionary<string,TransformData> targetTransformData;
    
    protected float restoreStartTime;

    protected bool isRestoringToSource;

    protected Transform[] transforms;
    protected Transform[] sourceTransforms;

    protected struct TransformData
    {
        public Vector3 position;
        public Quaternion rotation;

        public TransformData( Transform t )
        {
            position = t.position;
            rotation = t.rotation;
        }
    }

    //when the ragdoll is created, the SourceObject must be assigned –
    //the Ragdoll will disable that object while ragdolling, and
    //enable it again when it comes to rest.
    public GameObject SourceObject
    {
        get;
        set;
    }

    public void Start ()
    {
        //when we start, copy over everything from the source to look like this ragdoll
        transform.position = SourceObject.transform.position;

        transforms = GetComponentsInChildren<Transform>();
        sourceTransforms = SourceObject.GetComponentsInChildren<Transform>();
        CopyTransforms( sourceTransforms, transforms );

        SourceObject.gameObject.SetActive( false );

        //this is hacky... is there a better, more generic way of changing the camera target?
        OverShoulderCam cam = Camera.main.GetComponent<OverShoulderCam>();
        FollowCam followCam = Camera.main.GetComponent<FollowCam>();
        if ( cam != null && followCam != null )
        {
            sourceCameraTarget = cam.target;
            followCam.target = rootRigidbody.transform;//cameraTarget == null ? rootRigidbody.transform : cameraTarget;
            followCam.enabled = true;
            cam.enabled = false;
        }
    }
    
    public void Update ()
    {
        if ( isRestoringToSource )
        {
            ContinueRestore();
        }
        else if ( IsOnValidPosition() )
        {
            RestoreToSource();
        }
        else if ( rootRigidbody.velocity.sqrMagnitude <= 0.01f )
        {
            ApplyCollisionForces( Vector3.up );
        }
    }

    public void OnCollisionStay( Collision other )
    {
        if ( ( collisionMask & ( 1 << other.gameObject.layer ) ) != 0 && !IsOnValidPosition() )
        {
            ApplyCollisionForces( other.contacts[0].normal );
        }
    }

    protected bool IsOnValidPosition()
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition( rootRigidbody.transform.position, out hit, 0.25f, NavMesh.AllAreas );
    }

    protected void RestoreToSource()
    {
        SourceObject.transform.position = rootRigidbody.transform.position;
        
        startTransformData = new Dictionary<string,TransformData>();
        for ( int transformIndex = 0; transformIndex < transforms.Length; transformIndex++ )
        {
            Transform trans = transforms[ transformIndex ];
            string key = trans.gameObject.name;
            startTransformData[ key ] = new TransformData( trans );
        }

        targetTransformData = new Dictionary<string,TransformData>();
        for ( int transformIndex = 0; transformIndex < sourceTransforms.Length; transformIndex++ )
        {
            Transform trans = sourceTransforms[ transformIndex ];
            string key = trans.gameObject.name;
            targetTransformData[ key ] = new TransformData( trans );
        }

        restoreStartTime = Time.time;
        isRestoringToSource = true;
    }

    protected void ContinueRestore()
    {
        float t = ( Time.time - restoreStartTime ) / restorePositionTime;

        for ( int transformIndex = 0; transformIndex < transforms.Length; transformIndex++ )
        {
            Transform trans = transforms[ transformIndex ];
            string key = trans.gameObject.name;
            if ( targetTransformData.ContainsKey( key ) )
            {
                trans.position = Vector3.Lerp( startTransformData[ key ].position, targetTransformData[ key ].position, t );
                trans.rotation = Quaternion.Lerp( startTransformData[ key ].rotation, targetTransformData[ key ].rotation, t );
            }
        }

        if ( t >= 1.0f )
        {
            CompleteRestore();
        }
    }

    protected void CompleteRestore()
    {
        //this is hacky... is there a better, more generic way of changing the camera target?
        OverShoulderCam cam = Camera.main.GetComponent<OverShoulderCam>();
        FollowCam followCam = Camera.main.GetComponent<FollowCam>();
        if ( cam != null && followCam != null )
        {
            cam.enabled = true;
            followCam.enabled = false;
            //cam.target = sourceCameraTarget;

        }

        SourceObject.gameObject.SetActive( true );
        Destroy( gameObject );
    }

    protected void CopyTransforms( Transform[] from, Transform[] to )
    {
        for ( int toIndex = 0; toIndex < to.Length; toIndex++ )
        {
            Transform tt = to[toIndex];
            for ( int fromIndex = 0; fromIndex < from.Length; fromIndex++ )
            {
                Transform ft = from[fromIndex];
                if ( tt.gameObject.name == ft.gameObject.name )
                {
                    tt.position = ft.position;
                    tt.rotation = ft.rotation;
                }
            }
        }
    }

    protected void ApplyCollisionForces( Vector3 tangent )
    {
        if ( upwardsForceAppliedOnCollision != 0.0f || tangentialForceAppliedOnCollision != 0.0f )
        {
            rootRigidbody.AddForce( rootRigidbody.mass * upwardsForceAppliedOnCollision * Vector3.up );
            rootRigidbody.AddForce( rootRigidbody.mass * tangentialForceAppliedOnCollision * tangent );
        }
    }
}
