using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Press_Red : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite originalSprite;
    public bool canStrum = false;
    bool active = false;
    GameObject note;
    public ScoreCounter scoreCounter;

    bool isHammer = false;
    bool songEnd = false;


    // Create audio object for E note
    public AudioSource dNote;

    private bool isFreestyle = false;

    void Start()
    {
    	spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
       
        
    }

    public bool songEnded()
    {
        // do something
        print("song ended");
        return songEnd;
    }

    public void Onpress_red(InputAction.CallbackContext context){
    	if (context.started)
     	{
         //button is press
     		spriteRenderer.sprite = newSprite;

            canStrum = true;
            if (active && isHammer)
            {
                notePlayed();
            }
        }
     	else if (context.canceled)
     	{
         //button is released
     		spriteRenderer.sprite = originalSprite;

            canStrum = false;
        }
    }
    public void On_strum(InputAction.CallbackContext context){
        if (context.started)
        {
                //Only play audio if user is in freestyle mode
            if (isFreestyle && canStrum)
            {
                dNote.Play();
            }
            else if (canStrum && active)
            {
                notePlayed();
            }
        }
        else if (context.canceled)
        {
            if (isFreestyle)
            {
                dNote.Stop();
            }
        }
    }
    public void notePlayed()
    {
        active = false;
        scoreCounter.increaseScore();
        Destroy(note);
    }
    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Red Note(Clone)")
        {
            note = col.gameObject;
            active = true;
            if (note.tag == "Hammer" || note.tag == "LastHammer")
            {
                isHammer = true;

            }
            else
            {
                isHammer = false;
            }

            if (note.tag == "Last" || note.tag == "LastHammer")
            {
                songEnd = true;
                songEnded();
                songEnd = false;
            }

        }

    }
    public void OnTriggerExit(Collider col)
    {
        active = false;
        scoreCounter.brokenStreak();
    }
}
