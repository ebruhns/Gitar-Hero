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


    // Create audio object for E note
    public AudioSource dNote;

    private bool isFreestyle = true;

    void Start()
    {
    	spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (active) { }
    }

    public void Onpress_red(InputAction.CallbackContext context){
    	if (context.started)
     	{
         //button is press
     		spriteRenderer.sprite = newSprite;

            //canStrum = true;
        }
     	else if (context.canceled)
     	{
         //button is released
     		spriteRenderer.sprite = originalSprite;

            //canStrum = false;
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
        }
        else if (context.canceled)
        {
            if (isFreestyle)
            {
                dNote.Stop();
            }
        }
    }
    public void onTriggerEnter(Collision col)
    {
        print("Collision Detected");
        if (col.gameObject.name == "Red Note(Clone)")
        {
            Debug.Log("fdhsjakfhdsjak");
        }

        if (col.gameObject.tag == "Note")
        {
            note = col.gameObject;
            active = true;
        }
    }
    public void onTriggerExit(Collision col)
    {
        active = false;
    }
}
