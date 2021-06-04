using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Press_Yellow : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite originalSprite;
    public bool canStrum = false;
    bool active = false;
    GameObject note;
    bool isHammer = false;
    public ParticleSystem particleSystem;

    public ScoreCounter scoreCounter;

    // Create audio object for E note
    public AudioSource eNote;
    private bool isFreestyle = false;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();

    }

    public void songEnded()
    {
        scoreCounter.songEndedHelper();
    }

    public void Onpress_yellow(InputAction.CallbackContext context)
    {
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

    public void On_strum(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //Only play audio if user is in freestyle mode
            if (isFreestyle && canStrum)
            {
                eNote.Play();
            }
            else if (canStrum && active)
            {
                notePlayed();
            }
            else if (canStrum && !active)
            {
                scoreCounter.brokenStreak();
            }
        }
        else if (context.canceled)
        {
            if (isFreestyle)
            {
                eNote.Stop();
            }
        }
    }

    public void notePlayed()
    {
        active = false;
        scoreCounter.increaseScore();
        particleSystem.Play();
        scoreCounter.increaseTotalNotes();
        Destroy(note);
    }

    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Yellow Note(Clone)")
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
                
                songEnded();
                
            }

        }

    }
    public void OnTriggerExit(Collider col)
    {
        active = false;
        scoreCounter.brokenStreak();
        scoreCounter.increaseTotalNotes();
    }
}
