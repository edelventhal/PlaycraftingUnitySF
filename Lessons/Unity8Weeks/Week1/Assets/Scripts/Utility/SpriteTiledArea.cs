using UnityEngine;

//this is a handy class that will create a bunch of sprites to fill a space.
//note that this is super duper inefficient for big areas – a better option
//is to write a custom shader. But that's out of the scope of this class!
public class SpriteTiledArea : MonoBehaviour
{
    public SpriteRenderer tilePrefab;
    public Sprite[] sprites;
    public Vector2 size;

    public void Start()
    {
        Vector2 tileSize = tilePrefab.bounds.size;
        for ( float x = 0; x < size.x; x += tileSize.x )
        {
            for ( float y = 0; y < size.y; y += tileSize.y )
            {
                SpriteRenderer rend = Instantiate<SpriteRenderer>( tilePrefab );
                rend.sprite = sprites[ Random.Range( 0, sprites.Length ) ];
                rend.transform.parent = transform;
                rend.transform.localPosition = new Vector3( x - size.x / 2.0f + tileSize.x / 2.0f, y - size.y / 2.0f + tileSize.y / 2.0f, 0.0f );
            }
        }
    }
}
