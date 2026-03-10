using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    private bool facingright = true;
    public float speed;
    public Transform[] patrolPoints;
    public float waitTime;
    int currentPointIndex;
    bool once;

    public Animator anim;
    void Update()
    {
        if (Vector2.Distance(transform.position, patrolPoints[currentPointIndex].position) > 0.2f)
        {
            anim.SetFloat("speed",1);
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        }else
        {
            anim.SetFloat("speed", 0);
            if (once == false)
            {
                once = true;

                StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        flip();
        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            currentPointIndex++;
        }else
        {
            currentPointIndex = 0;
        }
        once = false;
    }
    private void flip()
    {
        facingright = !facingright;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
