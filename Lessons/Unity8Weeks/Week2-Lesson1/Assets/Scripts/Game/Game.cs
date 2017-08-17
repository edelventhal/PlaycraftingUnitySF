using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Tooltip ("The player. If this is dead, the game is lost.")]
    public Destructible player;

    [Tooltip ("How many gems until we win?")]
    public int gemWinCount = 5;

    [Tooltip ("How many hearts do we start with?")]
    public int heartCount = 3;

    [Tooltip ("This is how many easter eggs we need for the special ending.")]
    public int easterEggBonusCount = 1;

    [Tooltip ("This is the item ID for the gems we want to collect.")]
    public string gemItemId = "gem";

    [Tooltip ("This is the item ID for the easter eggs we want to collect.")]
    public string easterEggItemId = "easterEgg";

    public enum GameState
    {
        Playing,
        Won,
        Lost,
        WonWithEasterEgg
    };

    //everything through Awake is called a "singleton" pattern,
    //and this is how you'd typically do it in Unity.
    //it forces there to be only one Game, and we can access it from anywhere
    //using the "static" keyword. static means we don't need an instance
    //of this object for that function to be useable
    public static Game Instance
    {
        get;
        protected set;
    }
    public void Awake() 
    {
        //if there is already an instance, destroy it.
        if ( Instance != null )
        {
            Destroy( Instance.gameObject );
        }

        //assign the static variable to be this object, so we can get it from anywhere
        Instance = this;

        //Unity will never automatically destroy this object
        DontDestroyOnLoad( gameObject );
    }

    public void Update() 
    {
        RefreshState();
    }

    //this is called a "property"
    //it's just a shorthand to allow us to create a "getter" and/or a "setter"
    //for a variable. It will create a variable for us, and if we say "get"
    //will create a way to get that variable, and "set" will let us set it.
    //we can control access to each with the usual public private protected etc.
    //in this case, other classes can get the value, but only this and subclasses can change it.
    public GameState State
    {
        get;
        protected set;
    }

    protected void RefreshState()
    {
        //if we lost, the state can't change
        if ( State == GameState.Lost )
        {
            return;
        }

        //first, check to see if we died
        if ( PlayerDied() )
        {
            State = GameState.Lost;
            return;
        }

        //if we haven't lost and already have the easter egg, the state can't change
        if ( State == GameState.WonWithEasterEgg )
        {
            return;
        }

        //if we already won, check for the easter egg
        if ( State == GameState.Won )
        {
            if ( GotEasterEgg() )
            {
                State = GameState.WonWithEasterEgg;
            }
            return;
        }

        //finally, check to see if we won
        if ( WonGame() )
        {
            State = GameState.Won;
            return;
        }
    }

    protected bool PlayerDied()
    {
        return  player == null || player.isDying;
    }

    protected bool GotEasterEgg()
    {
        return player.GetComponent<PickupGetter>().GetPickupCount( easterEggItemId ) >= easterEggBonusCount;
    }

    protected bool WonGame()
    {
        return player.GetComponent<PickupGetter>().GetPickupCount( gemItemId ) >= gemWinCount;
    }
}
