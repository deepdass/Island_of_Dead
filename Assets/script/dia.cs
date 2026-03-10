using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dia : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("endthis", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void endthis()
    {
        anim.SetBool("enddia", true);
    }
}
