using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ladder : MonoBehaviour
{
    public Rigidbody2D player1;
    public float ladderclimb;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            if (Input.GetKey(KeyCode.Space)) {
                player1.velocity = transform.up * ladderclimb* Time.deltaTime;
            }
        }
    }
}
