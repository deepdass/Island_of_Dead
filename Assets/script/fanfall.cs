using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanfall : MonoBehaviour
{
    public float waittime;
    public float setactive;
    
    public CapsuleCollider2D capsule;
    public SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("startfall",waittime);
        }
    }
    public void startfall()
    {
        gameObject.layer = default;
        capsule.enabled = false;
        Invoke("tosetactive", setactive);
        
        spriteRenderer.enabled = false;
    }
    public void tosetactive()
    {
        gameObject.layer = LayerMask.NameToLayer("ground");
        capsule.enabled = true;
        
        spriteRenderer.enabled = true;
        
        
    }
}
