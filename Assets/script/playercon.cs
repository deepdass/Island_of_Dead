using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercon : MonoBehaviour
{
    public noofheart noofheartscript;
    public float speed;
    public float jumpforce;
    private float moveinput;
    public GameObject blood;

    static public bool facingright = true;

    public bool isgrounded;
    public Transform groundcheak;
    public float cheakradius;
    public LayerMask whatisground;

    private int noofjumps = 2;
    public int extrajumpvalue;

    private Rigidbody2D rb;

    public Animator anim;
    public int health;
    static public bool isdead;

    public healthslider healthslider;
    public Vector2 checkpos;
    [SerializeField] private int addhealth;
    public bool deadbywater;

    [SerializeField] GameObject m_JumpDust;
    [SerializeField] GameObject m_LandingDust;
    public AudioSource hurtaudio;

    public float towait;

    //public GameMaster Master;

    void Start()
    {
        //Master = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        //transform.position = Master.lastCheakpointpos;
        addhealth = health;
        healthslider.setmaxhealth(health);
        noofjumps = extrajumpvalue;
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {

        isgrounded = Physics2D.OverlapCircle(groundcheak.position, cheakradius, whatisground);
        moveinput = Input.GetAxisRaw("Horizontal");
        if (moveinput == 1)
        {
            rb.velocity = new Vector2(moveinput * speed * Time.deltaTime, rb.velocity.y);
            Vector3 Scaler = transform.localScale;
            Scaler.x = -1;
            transform.localScale = Scaler;
            facingright = true;
            
        }
        else if (moveinput == -1) {
            rb.velocity = new Vector2(moveinput * -speed * Time.deltaTime, rb.velocity.y);
            Vector3 Scaler = transform.localScale;
            Scaler.x = 1;
            transform.localScale = Scaler;
            facingright = false;
            
        }
        else if (moveinput == 0)
        {
            
        }
        rb.velocity = new Vector2(moveinput * speed * Time.deltaTime,rb.velocity.y);
        anim.SetFloat("Speed" , Mathf.Abs(moveinput));

       
    }
    void Update()
    {
        if (isgrounded == true) 
        {
            noofjumps = extrajumpvalue;
            anim.SetBool("jump", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && noofjumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            noofjumps--;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && noofjumps == 0 && isgrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
            Instantiate(m_JumpDust, groundcheak.position, Quaternion.identity);
            Invoke("waittimeover", towait);
        }
        if (isgrounded == false) 
        {
            anim.SetBool("jump", true);
        }
    }

    public void takedamage(int damage) {
        anim.ResetTrigger("hurtclose");
        health -= damage;
        healthslider.sethealth(health);
        anim.SetTrigger("hurt");
        Invoke("Resetrigger", 0.9f);
        hurtaudio.enabled = true;
        if (deadbywater == false) {
            Instantiate(blood, transform.position, Quaternion.identity);
        }
        if (health <= 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            health = addhealth;
            healthslider.sethealth(health);
            noofheartscript.noofhearts -= 1;
            transform.position = checkpos;
            isdead = true;
        }
    }
    public void Resetrigger()
    {
        anim.SetTrigger("hurtclose");
        hurtaudio.enabled = false;
    }
    public void waittimeover() {
        if (isgrounded == true) {
            Instantiate(m_LandingDust, groundcheak.position, Quaternion.identity);
        }
    }
}
