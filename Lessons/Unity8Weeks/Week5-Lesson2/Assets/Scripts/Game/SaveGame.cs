using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public Transform[] savedTransforms;

    public const string POSITION = "position";
    public const string X = "x";
    public const string Y = "y";
    public const string Z = "z";

    public void Start()
    {
        Load();
    }
    
    public void OnDestroy()
    {
        Save();
    }

    public void Load()
    {
        for ( int transformIndex = 0; transformIndex < savedTransforms.Length; transformIndex++ )
        {
            if ( PlayerPrefs.HasKey( GetPositionKeyComponent( transformIndex, X ) ) )
            {
                Vector3 pos = new Vector3( PlayerPrefs.GetFloat( GetPositionKeyComponent( transformIndex, X ) ),
                                           PlayerPrefs.GetFloat( GetPositionKeyComponent( transformIndex, Y ) ),
                                           PlayerPrefs.GetFloat( GetPositionKeyComponent( transformIndex, Z ) ) );
                savedTransforms[ transformIndex ].position = pos;
            }
        }
    }

    public void Save()
    {
        for ( int transformIndex = 0; transformIndex < savedTransforms.Length; transformIndex++ )
        {
            if ( savedTransforms[ transformIndex ] != null )
            {
                Vector3 pos = savedTransforms[ transformIndex ].position;
                PlayerPrefs.SetFloat( GetPositionKeyComponent( transformIndex, X ), pos.x );
                PlayerPrefs.SetFloat( GetPositionKeyComponent( transformIndex, Y ), pos.y );
                PlayerPrefs.SetFloat( GetPositionKeyComponent( transformIndex, Z ), pos.z );
            }
        }
    }

    private static string GetPositionKey( int transformIndex )
    {
        return POSITION + "." + transformIndex;
    }

    private static string GetPositionKeyComponent( int transformIndex , string component )
    {
        return GetPositionKey( transformIndex ) + "." + component;
    }
}
