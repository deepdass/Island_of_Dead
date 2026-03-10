using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationlimit : MonoBehaviour
{
    public float sign;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball") {
            wballrotation.rotationspeed = sign;
        }
    }
}
