using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class noofheart : MonoBehaviour
{
    public int noofhearts;
    public Image[] hearts;
    public restart torestart;

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (noofhearts == 0)
            { 
                torestart.restartthelevel();
            }
            if (i < noofhearts)
            {
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
        }
    }
}
