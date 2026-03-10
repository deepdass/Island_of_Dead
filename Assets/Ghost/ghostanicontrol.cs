using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class ghostanicontrol : MonoBehaviour
{
    public GameObject[] enemys;
    public Transform player;
    private float dist;
    public float howclose;
    private Enemy enemyscript;
    public Animator anim;
    private string currentstate;
    private string nextstate;
    private bool closetosomeone;
    void Start()
    {
        enemys = GameObject.FindGameObjectsWithTag("enemy");
        changestate("appear");
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < enemys.Length; i++)
        {
            enemyscript = enemys[i].GetComponent<Enemy>();
            dist = Vector2.Distance(enemys[i].transform.position, player.position);
            bool isdeadcheak = enemyscript.isdead;
            if (closetosomeone == false)
            {
                
                if (dist > howclose && isdeadcheak == false || isdeadcheak == true)
                {
                    changestate("appear");
                    closetosomeone = false;
                }
                else if (dist <= howclose && isdeadcheak == false)
                {
                    changestate("disappear");
                    closetosomeone = true;
                }
                
            }
            else if (dist > howclose && isdeadcheak == false || dist > howclose && isdeadcheak == true)
            {
                closetosomeone = false;
            }
        }
    }
    public void changestate(string nextstate)
    {
        if (currentstate == "disappear" && nextstate == "appear") return;
        closetosomeone = false;
        if (nextstate == currentstate) return;

        anim.Play(nextstate);
        currentstate = nextstate;
    }
}
