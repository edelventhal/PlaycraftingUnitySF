using UnityEngine;
using UnityEngine.UI;

public class TalkyText : MonoBehaviour
{
    public float lettersPerSecond = 50.0f;
    public AudioClip initialSound;
    public AudioClip talkySound;
    public float talkyDelay = -1.0f;
    public bool startsBlank = false;
    public float minTimeBetweenTalkSounds = -1.0f;
    
    protected bool shouldModifyText;
    protected float modifyTextStartTime;
    protected string targetText;
    protected TextMesh textMesh;
    protected Text textGUI;
    
    protected string initialText;
    protected float timeUntilTalky;
    protected float lastTimePlayedTalkSound;
    
    public void Awake()
    {
        textMesh = GetComponent<TextMesh>();
        textGUI = GetComponent<Text>();
        
        shouldModifyText = false;
        lastTimePlayedTalkSound = Time.time - minTimeBetweenTalkSounds;
        
        if ( textGUI != null )
        {
            initialText = textGUI.text;
        }
        else
        {
            initialText = textMesh.text;
        }
        
        if ( textGUI != null )
        {
            textGUI.text = "";
        }
        else
        {
            textMesh.text = "";
        }
        
        if ( !startsBlank )
        {
            if ( talkyDelay >= 0.0f )
            {
                timeUntilTalky = talkyDelay;
            }
            else
            {
                BeginInitialTalky();
            }
        }
    }
    
    public void Update()
    {
        if ( talkyDelay >= 0.0f && !startsBlank )
        {
            timeUntilTalky -= Time.deltaTime / Time.timeScale;
            
            if ( timeUntilTalky <= 0.0f )
            {
                BeginInitialTalky();
            }
        }
        
        if ( shouldModifyText )
        {
            if ( GetComponent<AudioSource>() != null && !GetComponent<AudioSource>().isPlaying )
            {
                GetComponent<AudioSource>().clip = talkySound;
                GetComponent<AudioSource>().loop = true;
                GetComponent<AudioSource>().Play();
            }
            
            //this doesn't really work right when the timeScale is changed, since it doesn't account for multiple
            //scales happening during the course of writing. To do that, we'd need to keep track of the current letter
            int letterCount = (int) ( ( Time.time - modifyTextStartTime ) * ( lettersPerSecond / Time.timeScale ) );
            letterCount = Mathf.Min( letterCount, targetText.Length );
            string desiredText = targetText.Substring( 0, letterCount );
            DoSetText( desiredText );
            
            //done
            if ( letterCount >= targetText.Length )
            {
                shouldModifyText = false;
                
                if ( GetComponent<AudioSource>() != null )
                {
                    GetComponent<AudioSource>().Stop();
                }
            }
        }
    }
    
    public void SetText( string text )
    {
        SetText( text, true );
    }
    
    public void SetText( string text, bool playSound )
    {
        if ( playSound && GetComponent<AudioSource>() != null && initialSound != null )
        {
            if ( minTimeBetweenTalkSounds < 0 || Time.time - lastTimePlayedTalkSound >= minTimeBetweenTalkSounds )
            {
                GetComponent<AudioSource>().clip = initialSound;
                GetComponent<AudioSource>().loop = false;
                GetComponent<AudioSource>().Play();
                lastTimePlayedTalkSound = Time.time;
            }
        }
        
        if ( text == null )
        {
            text = "";
        }
        
        shouldModifyText = true;
        modifyTextStartTime = Time.time;
        if ( textMesh != null )
        {
            targetText = textMesh.text;
        }
        else if ( textGUI != null )
        {
            targetText = text;
        }
        
        DoSetText( "" );
        talkyDelay = -1.0f;
    }
    
    public void InstantlySetText()
    {
        if ( shouldModifyText )
        {
            InstantlySetText( targetText );
        }
        GetComponent<AudioSource>().Stop();
    }
    
    public void InstantlySetText( string text )
    {
        shouldModifyText = false;
        targetText = text;
        DoSetText( text );
    }
    
    public string GetInitialText()
    {
        return initialText;
    }
    
    public bool IsTalking()
    {
        if ( !shouldModifyText )
        {
            return false;
        }
        
        if ( textMesh != null )
        {
            return !targetText.Equals( textMesh.text );
        }
        else if ( textGUI != null )
        {
            return !targetText.Equals( textGUI.text );
        }
        
        return false;
    }
    
    protected void BeginInitialTalky()
    {
        SetText( initialText );
        talkyDelay = -1.0f;
    }
    
    protected void DoSetText( string text )
    {
        if ( textGUI != null )
        {
            textGUI.text = text;
        }
        else
        {
            textMesh.text = text;
        }
    }
}