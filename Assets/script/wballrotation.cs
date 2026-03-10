using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wballrotation : MonoBehaviour
{   
    static public float rotationspeed;
    public void Start()
    {
        rotationspeed = -65;
    }
    void Update()
    {
        transform.Rotate(Vector3.back * rotationspeed * Time.deltaTime);
    }
}
