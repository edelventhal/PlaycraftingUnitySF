using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Tooltip ("We'll make dupes of this object.")]
    public GameObject spawnedPrefab;
    
    [Tooltip ("If true, the object is spawned with this as its parent. If false, it's spawned within this's parent.")]
    public bool parentToThis = true;

    [Tooltip ("If this exists, then the object will be spawned at the location of this Transform.")]
    public Transform spawnTarget;

    public virtual void Spawn()
    {
        GameObject obj = Instantiate<GameObject>(spawnedPrefab);

        obj.transform.parent = parentToThis ? transform : transform.parent;
        obj.transform.position = spawnTarget != null ? spawnTarget.position : transform.position;
    }
}
