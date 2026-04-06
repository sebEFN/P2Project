using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{

    public void Press(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("meow");
            ApplyRedToChildren();
        }
    }
    void ApplyRedToChildren(){
        Transform tagRenderers = transform.Find("outline");
        SpriteRenderer spriteRenderer = tagRenderers.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color (255,0,0,255);
    }
    void ApplyBlackToChildren()
    {
        Transform tagRenderers = transform.Find("outline");
        SpriteRenderer spriteRenderer = tagRenderers.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;
    }
    void Update()
    {
        
    }

}
