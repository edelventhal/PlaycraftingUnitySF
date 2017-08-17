using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Tooltip ("We'll make dupes of this object.")]
    public GameObject[] spawnedPrefabs;
    
    [Tooltip ("If true, the object is spawned with this as its parent. If false, it's spawned within this's parent.")]
    public bool parentToThis = true;

    [Tooltip ("If this exists, then the object will be spawned at the location of this Transform.")]
    public Transform spawnTarget;

    public virtual GameObject Spawn()
    {
        GameObject obj = Instantiate<GameObject>(GetNextPrefab());

        obj.transform.parent = parentToThis ? transform : transform.parent;
        obj.transform.position = spawnTarget != null ? spawnTarget.position : transform.position;

        return obj;
    }

    protected virtual GameObject GetNextPrefab()
    {
        int randomIndex = Random.Range(0,spawnedPrefabs.Length);
        return spawnedPrefabs[randomIndex];
    }
}
