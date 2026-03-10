using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killpla : MonoBehaviour
{
    public playercon playerscript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            playerscript.takedamage(playerscript.health);
        }
    }
}
