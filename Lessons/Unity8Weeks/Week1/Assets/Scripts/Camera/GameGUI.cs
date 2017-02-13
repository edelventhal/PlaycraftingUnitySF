using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [Tooltip ("This entire GUI will be shown when we win.")]
    public GameObject wonGUI;
    [Tooltip ("This entire GUI object will be shown when we lose.")]
    public GameObject lostGUI;
    [Tooltip ("This is the won text.")]
    public Text wonText;

    [Tooltip ("When this Destructible no longer exists, we'll show the lostGUI.")]
    public Destructible player;

    public void Start()
    {
        //hide both of the game GUIs until we need them
        wonGUI.SetActive( false );
        lostGUI.SetActive( false );
    }
    
    public void Update()
    {
        lostGUI.SetActive( DidLoseGame() );
        wonGUI.SetActive( DidWinGame() );

        //these are pretty inefficient – shouldn't we only update the sprites if something has changed?
        UpdateHealthImages();
        UpdateGemImages();

        //easter egg!
        //it's very bad that we use FindPickupCount() so often, since it's very inefficient.
        if ( DidWinGame() && player.GetComponent<PickupGetter>().FindPickupCount( "easterEgg" ) >= 1 )
        {
            //it's also unnecessary to set this text every single time – we could do better
            wonText.text = "You REALLY won!";
        }
    }

    public bool DidLoseGame()
    {
        return  player == null || player.isDying;
    }

    public bool DidWinGame()
    {
        return !DidLoseGame() && player.GetComponent<PickupGetter>().FindPickupCount( "gem" ) >= 3;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene( "MainGame" );
    }

    protected void UpdateHealthImages()
    {
        float health = 0.0f;
        if ( player != null )
        {
            health = player.hitPoints;
        }

        for ( int healthImageIndex = 0; healthImageIndex < healthImages.Length; healthImageIndex++ )
        {
            //add one since the array is 0-indexed but our health is 1-indexed
            healthImages[ healthImageIndex ].gameObject.SetActive( health >= ( healthImageIndex + 1 ) );
        }
    }

    protected void UpdateGemImages()
    {
        int gemCount = 0;
        if ( player != null )
        {
            gemCount = player.GetComponent<PickupGetter>().FindPickupCount( "gem" );
        }

        for ( int gemImageIndex = 0; gemImageIndex < gemImages.Length; gemImageIndex++ )
        {
            gemImages[ gemImageIndex ].gameObject.SetActive( gemCount >= ( gemImageIndex + 1 ) );
        }
    }
}
