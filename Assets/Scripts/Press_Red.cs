using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Press_Red : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite originalSprite;

    void Start()
    {
    	spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Onpress_red(InputAction.CallbackContext context){
    	if (context.started)
     	{
         //button is press
     		spriteRenderer.sprite = newSprite; 
     	}
     	else if (context.canceled)
     	{
         //button is released
     		spriteRenderer.sprite = originalSprite; 
     	}
    }
}
