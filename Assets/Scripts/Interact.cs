using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour, IClickable
{
    public void OnClick() 
    {
        Debug.Log("somebody clicked me");
        ApplyRedToChildren();
    }
     void ApplyRedToChildren(){
        Transform tagRenderers = transform.Find("outline");
        SpriteRenderer spriteRenderer = tagRenderers.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color (255,0,0,255);
    }
}
    
      


