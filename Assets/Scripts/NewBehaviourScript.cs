using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public CharacterController2D controller;
    Rigidbody2D rb;
    
    public float fallMultiplier;
    public float jump;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    float horizontalmove = 0f;
    public float runspeed = 40f;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public Animator animator;
    public bool health;
    public static bool gameover;
    public GameObject GameOverScreen;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameOverScreen.SetActive(false);
    }

    
    void Update()
    {
        health = true;
        
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.AddForce(Vector2.up * jump);
           
        }
        if(gameObject.transform.position.y < -10)
        {
            health = false;
            GameObject.Destroy(gameObject);
            GameOverScreen.SetActive(true);
        }
        if (health = false)
        {
            gameover = true;
            GameOverScreen.SetActive(true);
            
        }

        horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalmove));

        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            animator.SetBool("isJumpings", true);
           if(jumpTimeCounter >0){ 
               rb.AddForce(Vector2.up * jump);
               jumpTimeCounter -= Time.deltaTime;
            }else
            {
                isJumping = false;
            }
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier -1) * Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        if(isGrounded == true)
        {
            animator.SetBool("isJumpings", false);
        }

    }

    public void OnLanding ()
    {
        animator.SetBool("isJumpings", false);
    }

    void FixedUpdate ()
    {
        controller.Move(horizontalmove * Time.fixedDeltaTime, false, false);
    }
}
