using System.Collections.Generic;
using UnityEngine;

public class LandingResponderSpawner : LandingResponder
{
    public GameObject prefab;

    public override void Landed()
    {
        GameObject spawned = Instantiate<GameObject>( prefab );
        spawned.transform.position = transform.position;
    }
}
