using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loot : MonoBehaviour
{
    public GameObject[] lootitem;
    public Animator ani;
    public loot lootdis;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F)) {
                for (int i = 0; i < lootitem.Length; i++)
                {
                    Instantiate(lootitem[i], transform.position, Quaternion.identity);
                }
                Destroy(lootdis);
                ani.Play("New Animation");
            }
        }
    }
}
