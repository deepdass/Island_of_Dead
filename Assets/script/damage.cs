using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public Animator animator;
    static private float timebtwatt;
    public float starttime = 0.5f;
    public Transform player;
    public int damagetotakebyplayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
            if (timebtwatt <= 0)
            {
                player.GetComponent<playercon>().takedamage(damagetotakebyplayer);
                timebtwatt = starttime;
            }
            else
            {
                timebtwatt -= Time.deltaTime;
            }
            
        }
    }
}
