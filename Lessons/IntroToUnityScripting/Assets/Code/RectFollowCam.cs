using UnityEngine;

//follows a transform (with no damping) unless that transform is within a rect in the center of the screen
[RequireComponent(typeof(Camera))]
public class RectFollowCam : MonoBehaviour
{
    public Transform target;
    public Vector2 noFollowSize = new Vector2( 0.5f, 0.5f );
    
    public void LateUpdate()
    {
        Camera cam = GetComponent<Camera>();
        
        //the no follow rect is calculated based upon the current location and size of the camera
        Vector2 camMinWorldPos = (Vector2) cam.ViewportToWorldPoint( Vector3.zero );
        Vector2 camMaxWorldPos = (Vector2) cam.ViewportToWorldPoint( Vector3.one );
        Vector2 camWorldSize = camMaxWorldPos - camMinWorldPos;
        Vector2 noFollowRectSize = Vector2.Scale( noFollowSize, camWorldSize );
        Rect noFollowRect = new Rect( camMinWorldPos + ( camWorldSize - noFollowRectSize ) / 2.0f, noFollowRectSize );

        if ( target != null )
        {
            Vector3 positionDelta = Vector3.zero;
            
            if ( target.transform.position.x < noFollowRect.x )
            {
                positionDelta.x = target.transform.position.x - noFollowRect.x;
            }
            else if ( target.transform.position.x > noFollowRect.x + noFollowRect.width )
            {
                positionDelta.x = target.transform.position.x - ( noFollowRect.x + noFollowRect.width );
            }
            
            if ( target.transform.position.y < noFollowRect.y )
            {
                positionDelta.y = target.transform.position.y - noFollowRect.y;
            }
            else if ( target.transform.position.y > noFollowRect.y + noFollowRect.height )
            {
                positionDelta.y = target.transform.position.y - ( noFollowRect.y + noFollowRect.height );
            }
            
            if ( transform.position != Vector3.zero )
            {
                transform.position += positionDelta;
            }
        }
    }
}