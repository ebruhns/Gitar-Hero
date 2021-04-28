using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Press_Red : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite originalSprite;

    // Create audio object for E note
    public AudioSource dNote;

    private bool isFreestyle = true;

    void Start()
    {
    	spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Onpress_red(InputAction.CallbackContext context){
    	if (context.started)
     	{
         //button is press
     		spriteRenderer.sprite = newSprite;

            //Only play audio if user is in freestyle mode
            if (isFreestyle)
            {
                dNote.Play();
            }
        }
     	else if (context.canceled)
     	{
         //button is released
     		spriteRenderer.sprite = originalSprite;

            //Only stop audio if user is in freestyle mode
            if (isFreestyle)
            {
                dNote.Stop();
            }
        }
    }
}
