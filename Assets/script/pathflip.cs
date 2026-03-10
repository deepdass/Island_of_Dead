using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathflip : MonoBehaviour
{
    public Transform scale;
    public Transform spawn;
    void Update()
    {
        transform.localScale = new Vector3(scale.localScale.x,1,1);
    }
}
