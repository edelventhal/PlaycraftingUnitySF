using UnityEngine;
using UnityEngine.UI;

public class DistanceReporter : MonoBehaviour
{
    [Tooltip("This text is changed to show the distance traveled.")]
    public Text distanceText;
    
    [Tooltip("We'll measure the distance this object has traveled.")]
    public Transform target;
    
    protected Vector3 startPosition;
    
    public void Start()
    {
        startPosition = target.transform.position;
    }
    
    public void Update()
    {
        if ( target != null )
        {
            distanceText.text = "" + (int) ( target.transform.position - startPosition ).magnitude;
        }
    }
}