using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastcheck : MonoBehaviour
{
    public playercon player1;
    public Transform player;

    public void lastcheckpos() {
        player.position = player1.checkpos;
    }
}
