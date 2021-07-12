using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    public float jumpvelocity;
    bool grounded = true;
    Animator animator;
    SpriteRenderer rend;
    Score scoretext;
    AudioSource playeraudio;
    public AudioClip jumpSound;
    public AudioClip coinSound;
    SAvePlayerData saveGet;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        scoretext =GameObject.Find("ScoreManage").GetComponent<Score>();
        playeraudio = GetComponent<AudioSource>();
        saveGet =GameObject.Find("Player").GetComponent<SAvePlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                Jump();
                animator.SetTrigger("Jump");
                playeraudio.clip = jumpSound;
                playeraudio.Play();
            }
            else
            {
                animator.SetTrigger("Stand");
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerRB.velocity =Vector2.right*10.0f;
            
            Flipright();
            if (grounded)
            {
                animator.SetTrigger("Walk");
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerRB.velocity = Vector2.left * 10.0f;
            if (grounded)
            {
                animator.SetTrigger("Walk");
            }
            Flipleft();
        }
        else
        {
            animator.SetTrigger("Stand");
        }
        //animator.SetTrigger("Idle");

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if ((collision.gameObject.tag == "Enemy")||(collision.gameObject.tag=="EnemyMove")||collision.gameObject.tag=="flame")
        {

            SceneManager.LoadScene(1);
            saveGet.SetData();
            saveGet.GetData();
        }
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            playeraudio.clip = coinSound;
            playeraudio.Play();
            scoretext.Increment();
        }
       
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            //Winning movement
            SceneManager.LoadScene(1);
            saveGet.SetData();
            saveGet.GetData();
        }
    }
    
    private void Jump()
    {
        grounded = false;
        playerRB.velocity = new Vector2(0, jumpvelocity);
    }
    void Flipright()
    {
        rend.flipX = false;
    }
    void Flipleft()
    {
        rend.flipX = true;
    }
}
