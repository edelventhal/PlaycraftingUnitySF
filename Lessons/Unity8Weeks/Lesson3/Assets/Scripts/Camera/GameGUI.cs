using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

//this decides what to show the player.
//it uses a "pull" or "polling" style of showing data.
//in other words, it constantly checks to see what data there is, and
//changes what it's showing based on what it finds.
//The opposite is called "pushing" data. When the player takes damage,
//he would tell the GameGUI to update its UI.
//The advantage to polling is that data is nicely encapsulated, so the
//core game functions with or without the UI existing.
//The disadvantage to polling is that it's less efficient, since we
//are constantly making calls every single frame.
public class GameGUI : MonoBehaviour
{
    [Tooltip ("Every image that shows your health should be here, in left-to-right order. We hide ones when health is missing.")]
    public Image[] healthImages;

    [Tooltip ("Every image that shows your gem count should be here, in left-to-right order. We hide ones when gems are missing.")]
    public Image[] gemImages;

    [Tooltip ("We'll change what's in this text based on what's in the result data.")]
    public Text resultText;

    [Tooltip ("We'll show this button or not based on what's in the result data.")]
    public Button restartButton;

    public ResultData[] resultData;

    //a struct is basically the same as a class, except it acts more like a primtive variable.
    //(like an int, or float, or bool, etc.) when you pass a struct as a parameter, the value
    //of the struct is copied ("pass by value"), whereas when you pass a class the class itself
    //is sent through, no copy is made ("pass by reference"). Here we are using a struct because
    //we want it to behave as if it's just another primtive type.
    //System.Serializable allows us to dive into this type in the inspector. Very handy!
    [System.Serializable]
    public struct ResultData
    {
        public Game.GameState state;
        public string text;
        public bool restartIsVisible;
    }
    protected Dictionary<Game.GameState,ResultData> resultDataLookup;

    protected Game.GameState lastShownState;
    protected float lastShownHitPoints;
    protected int lastShownGemCount;

    public void Awake() 
    {
        //the whole array of a struct in the inspector and having a private dictionary 
        //is a Unity design pattern to create a "lookup table", which is just a 
        //dictionary that matches values to some kind of key (in this case, a game state)
        resultDataLookup = new Dictionary<Game.GameState,ResultData>();

        //we're using a for loop here, which has 3 parts, separated by semicolons ;
        //the first part is the "initializer" and is used to create new variables. It happens right as the loop starts.
        //the second part is the "test expression". As long as it resolves to true, the loop will continue.
        //the third part is the "increment". This happens each time a loop completes.
        //all together, this causes this particular loop to go through every item in the resultData array.
        for ( int stringIndex = 0; stringIndex < resultData.Length; stringIndex++ )
        {
            ResultData rs = resultData[ stringIndex ];
            resultDataLookup[ rs.state ] = rs;
        }
    }

    public void Start()
    {
        UpdateUI( true );
    }
    
    public void Update()
    {
        UpdateUI( false );
    }

    public void RestartGame()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }

    protected void UpdateUI( bool force )
    {
        UpdateResultText( force );
        UpdateHealthImages( force );
        UpdateGemImages( force );
    }

    protected void UpdateResultText( bool force )
    {
        if ( !force && Game.Instance.State == lastShownState )
        {
            return;
        }

        ResultData rd = resultDataLookup[ Game.Instance.State ];
        resultText.text = rd.text;
        restartButton.gameObject.SetActive( rd.restartIsVisible );

        lastShownState = Game.Instance.State;
    }

    protected void UpdateHealthImages( bool force )
    {
        float hitPoints = Game.Instance.player != null ? Game.Instance.player.hitPoints : 0;

        if ( !force && lastShownHitPoints == hitPoints )
        {
            return;
        }

        for ( int healthImageIndex = 0; healthImageIndex < healthImages.Length; healthImageIndex++ )
        {
            //add one since the array is 0-indexed but our health is 1-indexed
            healthImages[ healthImageIndex ].gameObject.SetActive( hitPoints >= ( healthImageIndex + 1 ) );
        }

        lastShownHitPoints = hitPoints;
    }

    protected void UpdateGemImages( bool force )
    {
        int gemCount = Game.Instance.player != null ? Game.Instance.player.GetComponent<PickupGetter>().GetPickupCount( Game.Instance.gemItemId ) : 0;

        if ( !force && lastShownGemCount == gemCount )
        {
            return;
        }

        for ( int gemImageIndex = 0; gemImageIndex < gemImages.Length; gemImageIndex++ )
        {
            gemImages[ gemImageIndex ].gameObject.SetActive( gemCount >= ( gemImageIndex + 1 ) );
        }

        lastShownGemCount = gemCount;
    }
}
