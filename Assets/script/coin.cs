using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour
{
    public int coincount;
    public Text cointext;
    public AudioSource coinsource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin") {
            coinsource.Play();
            coincount += 1;
            cointext.text = coincount.ToString();
            Destroy(collision.gameObject);
        }
    }
}
