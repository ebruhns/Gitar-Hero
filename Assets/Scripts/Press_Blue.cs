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

    //Create Audio source for F note
    public AudioSource fNote;
    private bool isFreestyle = true;


    void Start()
    {
    	spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Onpress_blue(InputAction.CallbackContext context){
    	if (context.started)
     	{
         //button is press
     		spriteRenderer.sprite = newSprite;

            //Only play audio if user is in freestyle mode
            if (isFreestyle)
            {
                fNote.Play();
            }
        }
     	else if (context.canceled)
     	{
         //button is released
     		spriteRenderer.sprite = originalSprite;

            //Only stop audio if user is in freestyle mode
            if (isFreestyle)
            {
                fNote.Stop();
            }
        }
    }
}
