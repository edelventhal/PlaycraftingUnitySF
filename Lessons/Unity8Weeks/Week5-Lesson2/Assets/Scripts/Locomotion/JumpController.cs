using UnityEngine;

[RequireComponent(typeof(Jumper))]
public class JumpController : MonoBehaviour
{
    public string inputKey = "Jump";

    protected Jumper jumper;

    public void Awake() 
    {
        jumper = GetComponent<Jumper>();
    }

    public void Update() 
    {
        if ( Input.GetButtonDown( inputKey ) )
        {
            jumper.Jump();
        }
    }
}
