using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject blood;

    public Animator anim;

    public CapsuleCollider2D capsuledis;
    public patrol patroldis;

    public bool facingright = true;

    public Transform player;
    private float dist;
    public float mspeed;
    public float howclose;
    public bool flips;

    public playercon takedamagescript;
    private float enetrans;

    public bool isdead;

    public GameObject attackloc;
    public GameObject attackloc1;
    public GameObject attackloc2;
    public bool isgrounded;
    public Transform groundcheak;
    public float cheakradius;
    public LayerMask whatisground;

    public AudioSource hurtsource;
    public zombiecounts zombiecount;
    public GameObject coin;
    public healthslider healthslider;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        healthslider.setmaxhealth(health);
    }


    public void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(groundcheak.position, cheakradius, whatisground);
    }
    void Update()
    {
        dist = Vector2.Distance(transform.position, player.position);
        if (dist <= howclose && isdead == false && isgrounded == true)
        {
            Vector3 Scale = transform.localScale;
            if (player.transform.position.x < transform.position.x)
            {
                Scale.x = Mathf.Abs(Scale.x) * -1 * (flips ? -1 : 1);
                transform.Translate(mspeed * Time.deltaTime * -1, 0, 0);

            }
            else {
                Scale.x = Mathf.Abs(Scale.x) * (flips ? -1 : 1);
                transform.Translate(mspeed * Time.deltaTime, 0, 0);

            }
            transform.localScale = Scale;
            patroldis.enabled = false;

        }
        else if (dist >= howclose && isdead == false)
        {
            patroldis.enabled = true;
            Invoke("altflip", 0.1f);
            enetrans = transform.position.x;
        } else if (dist <= howclose && isdead == false && isgrounded == false) {
            patroldis.enabled = true;
        }
    }
    public void takeDamage(int damages) {
        Invoke("walk", 0.1f);
        hurtsource.enabled = true;
        Instantiate(blood, transform.position, Quaternion.identity);
        health -= damages;
        healthslider.sethealth(health);

        if (health <= 0)
        {
            healthslider.sethealth(health);
            canvas.enabled = false;
            anim.SetBool("dead", true);
            isdead = true;
            capsuledis.enabled = false;
            patroldis.enabled = false;
            Destroy(attackloc);
            Destroy(attackloc1);
            Destroy(attackloc2);
            zombiecount.zombiecount += 1;
            zombiecount.updatecount();
            Instantiate(coin, transform.position, Quaternion.identity);
            Instantiate(coin, transform.position, Quaternion.identity);
            Instantiate(coin, transform.position, Quaternion.identity);
        }
    }


    private void flip()
    {
        facingright = !facingright;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void altflip() {
        if (enetrans > transform.position.x && transform.localScale.x == 1)
        {
            flip();
        }
        else if (enetrans < transform.position.x && transform.localScale.x == -1)
        {
            flip();
        }
    }
    public void walk() 
    {
        hurtsource.enabled = false;
    }
}   
