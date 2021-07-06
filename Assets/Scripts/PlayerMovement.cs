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
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        scoretext =GameObject.Find("ScoreManage").GetComponent<Score>();
        playeraudio = GetComponent<AudioSource>();
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
                animator.SetTrigger("Idle");
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerRB.velocity =Vector2.right*10.0f;
            animator.SetTrigger("Walk");
            Flipright();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerRB.velocity = Vector2.left * 10.0f;
            animator.SetTrigger("Walk");
            Flipleft();
        }
        else
        {
            animator.SetTrigger("Idle");
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
            SceneManager.LoadScene(1);
        }
    }
    /*IEnumerator GameoverUI()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
        animator.SetTrigger("Death");
    }*/
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
