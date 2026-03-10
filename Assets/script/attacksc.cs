using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacksc : MonoBehaviour
{
    private float timebtwattack;
    public float starttimebtwattack;
    private float timebtwshot;
    public float starttimebtwshot;

    public Transform attackpos;
    public float attackrange;
    public LayerMask enemies;
    public int damage;

    public GameObject swoosh;
    public GameObject spawn;

    public GameObject[] slash;

    public Animator anim;
    void Update()
    {
        anim.SetBool("attack", false);
        if (timebtwattack <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                anim.SetBool("attack", true);
                Collider2D[] enemytodamage = Physics2D.OverlapCircleAll(attackpos.position, attackrange, enemies);
                for (int i = 0; i < enemytodamage.Length; i++)
                {
                    enemytodamage[i].GetComponent<Enemy>().takeDamage(damage);
                    Transform posit = enemytodamage[i].GetComponent<Transform>();
                    Instantiate(slash[Random.Range(0, slash.Length)], posit.transform.position, Quaternion.identity);
                }
                timebtwattack = starttimebtwattack;

            }
            
        }
        else {
            timebtwattack -= Time.deltaTime;
        
        }
        if (timebtwshot <= 0)
        {
            if (Input.GetMouseButton(1))
            {
                Instantiate(swoosh, spawn.transform.position, Quaternion.identity);
                timebtwshot = starttimebtwshot;
                anim.SetBool("attack", true);
            }
        }
        else
        {
            timebtwshot -= Time.deltaTime;

        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpos.position, attackrange);
    }

}
