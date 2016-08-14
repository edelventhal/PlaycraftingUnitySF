using UnityEngine;

//spawns objects below the camera
public class ObjectSpawner : MonoBehaviour
{
    [Tooltip("Each time spawning happens, a random one of these objects will be spawned.")]
    public GameObject[] spawnableObjectPrefabs;
    
    [Tooltip("What's the minimum amount of the time between spawns?")]
    public float minSpawnFrequency = 0.1f;
    
    [Tooltip("What's the maximum amount of time between spawns?")]
    public float maxSpawnFrequency = 0.3f;
    
    [Tooltip("Spawn this much offset from the bottom of the camera.")]
    public Vector2 spawnOffsetFromCameraBottom = new Vector2( 0.0f, -1.0f );
    
    protected float nextSpawnTime;
    
    public void Start()
    {
        //we want to spawn right away
        nextSpawnTime = Time.time;
    }
    
    //since we're not doing any physics, we'll use regular update
    public void Update()
    {
        if ( Time.time >= nextSpawnTime )
        {
            Spawn();
        }
    }
    
    public void Spawn()
    {
        //choose a random prefab to spawn, and then do so
        GameObject spawnedObject = Instantiate<GameObject>( spawnableObjectPrefabs[ Random.Range( 0, spawnableObjectPrefabs.Length ) ] );
        
        //we'll use the camera bounds to decide how to position the object
        Camera cam = Camera.main;
        Vector2 camMinWorldPos = (Vector2) cam.ViewportToWorldPoint( Vector3.zero );
        Vector2 camMaxWorldPos = (Vector2) cam.ViewportToWorldPoint( Vector3.one );
        Vector2 camWorldSize = camMaxWorldPos - camMinWorldPos;
        
        //move that object below the camera
        Vector3 objectPos = new Vector3( camMinWorldPos.x + Random.Range( -camWorldSize.x / 2.0f, camWorldSize.x / 2.0f ), camMinWorldPos.y, 0.0f );
        
        //and change the offset
        objectPos += (Vector3) spawnOffsetFromCameraBottom;
        
        spawnedObject.transform.position = objectPos;
        
        //make sure to increment the time we next spawn
        nextSpawnTime = Time.time + Random.Range( minSpawnFrequency, maxSpawnFrequency );
    }
}