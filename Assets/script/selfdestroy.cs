using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdestroy : MonoBehaviour
{
    public float lifespan;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("selfdestroys",lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void selfdestroys()
    {
        Destroy(gameObject);
    }
}
