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

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
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
        if (collision.gameObject.tag == "Enemy")
        {

            SceneManager.LoadScene(1);
        }
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            animator.SetTrigger("Death");
            StartCoroutine("GameoverUI");
        }

    }
    IEnumerator GameoverUI()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
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
