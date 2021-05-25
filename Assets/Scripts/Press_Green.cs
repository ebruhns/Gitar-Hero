using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;



public class Press_Green : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite originalSprite;
    public bool canStrum = false;
    public ChartLoaderTest chartLoaderTest;
    bool active = false;
    GameObject note;
    bool isHammer = false;



    // Create audio object for C note
    public AudioSource cNote;
    
    private bool isFreestyle = false;
   

    void Start()
    {
    	spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
       
    }

    public void Onpress_green(InputAction.CallbackContext context){
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

    public void notePlayed()
    {
        Destroy(note);
    }



    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Green Note(Clone)")
        {
            note = col.gameObject;
            active = true;
            if (note.tag == "Hammer")
            {
                isHammer = true;
                
            }
            else
            {
                isHammer = false;
            }

        }

    }
    public void OnTriggerExit(Collider col)
    {
        active = false;
    }


    public void On_strum(InputAction.CallbackContext context){
        if (context.started)
        {
                //Only play audio if user is in freestyle mode
            if (isFreestyle && canStrum)
            {
                cNote.Play();
               
            }
            else if (canStrum && active)
            {
                Destroy(note);
            }
        }
        else if (context.canceled)
        {
            if (isFreestyle)
            {
                cNote.Stop();
            }
        }
    }
}
