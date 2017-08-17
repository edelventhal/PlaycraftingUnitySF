using System.Collections.Generic;
using UnityEngine;

//a ParallaxCam will move multiple transforms around at different speeds,
//which creates a cool parallax effect.
public class ParallaxCam : MonoBehaviour
{
    [Tooltip ("All transforms in this list will be scrolled as the camera moves. 1.0 will match the camera's movements, and 0.0 won't move at all.")]
    public ParallaxTransform[] parallaxTransforms;

    [Tooltip ("The movement of the transforms will be scaled in each dimension by this amount. You can use this to scroll only on X or Y.")]
    public Vector2 directionMultiples = new Vector2( 1.0f, 0.0f );

    [System.Serializable]
    public struct ParallaxTransform
    {
        public Transform transform;
        public float parallaxSpeed;
    }

    //we need to know the last position of the camera so we can find the difference each frame
    protected Vector3 lastPosition;

    public void Start()
    {
        lastPosition = transform.position;
    }
    
    public void Update()
    {
        //"delta" is a fancy way of saying "difference over time"
        //in this case, we're storing the difference since the last frame.
        Vector3 positionDelta = transform.position - lastPosition;

        //now scale our vector by the direction multiples so we only go in whatever directions we want.
        //the Scale function is the same as positionDelta.x * directionMultiples.x, positionDelta.y * directionMultiples.y
        positionDelta.Scale( directionMultiples );

        for ( int transformIndex = 0; transformIndex < parallaxTransforms.Length; transformIndex++ )
        {
            ParallaxTransform pt = parallaxTransforms[ transformIndex ];

            //because the camera is moving, the backgrounds will naturally move with it.
            //to make a parallax effect work, we actually need to reduce the camera's
            //movements a bit... that will give the apperance of the different layers
            //moving more slowly than the camera is.
            pt.transform.position += positionDelta * ( 1.0f - pt.parallaxSpeed );
        }

        //make sure to update the last position.
        lastPosition = transform.position;
    }
}
