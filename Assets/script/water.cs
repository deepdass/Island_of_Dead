using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public GameObject spawnparticles;
    public playercon playercon;
    public healthslider healthslider;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(spawnparticles, other.transform.position, Quaternion.identity);
            Invoke("deadbywaterfalse", 0.5f);
            playercon.deadbywater = true;
            playercon.takedamage(playercon.health);
            healthslider.sethealth(playercon.health);
            
            playercon.isdead = true;
        }
    }
    public void deadbywaterfalse() {
        playercon.deadbywater = false;
    }
}