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

    void Start()
    {
    	spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Onpress_yellow(InputAction.CallbackContext context){
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
