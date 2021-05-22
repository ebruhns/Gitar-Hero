using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Press_Blue : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite originalSprite;
    public bool canStrum = false;
    bool active = false;
    GameObject note;

    //Create Audio source for F note
    public AudioSource fNote;
    private bool isFreestyle = false;


    void Start()
    {
    	spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (active) { }
    }



    public void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.name == "Blue Note(Clone)")
        {
            print("blue note");
            note = col.gameObject;
            active = true;
        }

        
    }
    public void OnTriggerExit(Collider col)
    {
        active = false;
    }

    public void Onpress_blue(InputAction.CallbackContext context){
    	if (context.started)
     	{
         //button is press
     		spriteRenderer.sprite = newSprite;
            canStrum = true;
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
                fNote.Play();
            }
            else if(canStrum && active)
            {
                Destroy(note);
            }
        }
        else if (context.canceled)
        {
            if (isFreestyle)
            {
                fNote.Stop();
            }
        }
    }
}
