using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class projectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public SpriteRenderer spr;
    public float lifetime;
    public GameObject particledes;


    private void Start()
    {
        Invoke("destroyproj", lifetime);
        if (spr.flipX == true)
        {
            spr.flipX = false;
        }
        if (playercon.facingright == true)
        {
            rb.velocity = transform.right * speed ;
        }
        else if (playercon.facingright == false)
        {
            spr.flipX = true;
            rb.velocity = transform.right * -speed ;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            other.GetComponent<Enemy>().takeDamage(2);
            Destroy(gameObject);
        }
        else if (other.tag == "ground" || other.tag == "wall") {
            Destroy(gameObject);
            Instantiate(particledes, transform.position, Quaternion.identity);
        }
    }
    public void destroyproj() {
        Destroy(gameObject);
        Instantiate(particledes, transform.position, Quaternion.identity);
    }

}
