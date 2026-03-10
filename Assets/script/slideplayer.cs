using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideplayer : MonoBehaviour
{
    public Transform player1;
    public float slideforce;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector3 scale = player1.localScale;
            player1.Translate(slideforce * scale.x * Time.deltaTime, 0, 0);
            
            
        }
    }
}
