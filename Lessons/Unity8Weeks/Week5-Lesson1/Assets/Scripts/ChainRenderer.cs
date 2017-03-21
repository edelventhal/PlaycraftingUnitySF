using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ChainRenderer : MonoBehaviour
{
    [Tooltip ("The joint that we're using to represent this chain.")]
    public Joint joint;

    [Tooltip ("How many sections we have in our chain. More is prettier but less efficient.")]
    public int controlPointCount = 6;

    [Tooltip ("Controls how quickly the chain control points catch up. A higher value is faster.")]
    public float pointLerpDamping = 0.2f;

    protected Vector3[] linePoints;

    protected LineRenderer lineRenderer;

    public void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.numPositions = Mathf.Max( 2, controlPointCount + 1 );

        linePoints = new Vector3[ lineRenderer.numPositions ];
        pointLerpDamping = Mathf.Clamp( pointLerpDamping, 0, 1 );
    }

    public void Start()
    {
        Vector3 body1Pos = joint.transform.position;
        Vector3 body2Pos = joint.connectedBody.transform.position;
        Vector3 delta = body2Pos - body1Pos;

        linePoints[0] = body1Pos;

        for ( int pointIndex = 1; pointIndex < controlPointCount; pointIndex++ )
        {
            linePoints[ pointIndex ] = delta * ( pointIndex / (float) controlPointCount ) + body1Pos;
        }

        linePoints[linePoints.Length - 1] = body2Pos;

        RedrawLineRenderer();
    }
    
    public void Update ()
    {
        UpdatePoints();
    }

    protected void UpdatePoints()
    {
        Vector3 body1Pos = joint.transform.position;
        Vector3 body2Pos = joint.connectedBody.transform.position;
        Vector3 delta = body2Pos - body1Pos;

        linePoints[0] = body1Pos;

        for ( int pointIndex = 1; pointIndex < controlPointCount; pointIndex++ )
        {
            Vector3 targetPos = delta * ( pointIndex / (float) controlPointCount ) + body1Pos;
            float lerpFraction = Mathf.Clamp( Time.deltaTime * pointLerpDamping, 0.0f, 1.0f );
            linePoints[ pointIndex ] = ( 1.0f - lerpFraction ) * linePoints[ pointIndex ] + lerpFraction * targetPos;
        }

        linePoints[linePoints.Length - 1] = body2Pos;

        RedrawLineRenderer();
    }

    protected void RedrawLineRenderer()
    {
        lineRenderer.SetPositions( linePoints );
    }
}
