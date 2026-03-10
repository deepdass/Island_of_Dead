using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint1 : MonoBehaviour
{
    public playercon updatecheakpoint1;
    public  BoxCollider2D Boxdis;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            updatecheakpoint1.checkpos = transform.position;
          
            Boxdis.enabled = false;
        }
    }
}
