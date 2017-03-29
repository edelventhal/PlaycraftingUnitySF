using System.Collections.Generic;
using UnityEngine;

public class LandingResponder : MonoBehaviour
{
    public virtual void Jumped()
    {

    }
    
    public virtual void Landed()
    {
        
    }

    public virtual bool CanLand()
    {
        return true;
    }
}
