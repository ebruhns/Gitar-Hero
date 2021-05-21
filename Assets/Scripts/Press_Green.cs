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
            if (active)
            {

            }
            

            canStrum = true;
            
     	}
     	else if (context.canceled)
     	{
         //button is released
     		spriteRenderer.sprite = originalSprite;
            
            canStrum = false;
        }
    }

    public void onTriggerEnter(Collision col)
    {
        print("Collision Detected");
        if (col.gameObject.name == "Blue Note(Clone)")
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
