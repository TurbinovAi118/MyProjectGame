using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCntrl2D : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRend;
    private bool isGrounded = true;
    //private bool block = false;
    public float runSpeed = 5f;
    public float rollSpeed = 7.5f;
    public float jumpSpeed = 25f;
    private Animator anim;

    [SerializeField]
    Transform GroundCheck;
    [SerializeField]
    Transform GroundCheck_L;
    [SerializeField]
    Transform GroundCheck_R;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if(Physics2D.Linecast(transform.position, GroundCheck.position, 1<<LayerMask.NameToLayer("Solid")) ||
            (Physics2D.Linecast(transform.position, GroundCheck_L.position, 1 << LayerMask.NameToLayer("Solid"))) ||
            (Physics2D.Linecast(transform.position, GroundCheck_R.position, 1 << LayerMask.NameToLayer("Solid")))) 
        {
            isGrounded = true;
            anim.SetBool("isFalling", false);
        }//checking ground
        
        else  
        {
            isGrounded = false;
            anim.SetBool("isFalling", true);
        } //checking ground

        if (Input.GetKey(KeyCode.D)) 
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            spriteRend.flipX = false;
            anim.SetBool("isRunning", true);
        }//moving right

        else if (Input.GetKey(KeyCode.A)) 
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            spriteRend.flipX = true;
            anim.SetBool("isRunning", true);
        }//moving left

        else if((Input.GetKey(KeyCode.S) && spriteRend.flipX == false) && isGrounded == true) 
        {
            rb2d.velocity = new Vector2(rollSpeed, rb2d.velocity.y);
            anim.SetBool("isRolling", true);
        }//rolling_right

        else if((Input.GetKey(KeyCode.S) && spriteRend.flipX == true) && isGrounded == true)  
        {
            rb2d.velocity = new Vector2(-rollSpeed, rb2d.velocity.y);
            anim.SetBool("isRolling", true);
        }//rolling_legt

        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded == true)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            anim.SetBool("isJumping", true);
        }//jumping

        else if (Input.GetKey(KeyCode.B))
        {
            //block = true;
            anim.SetBool("isBlocking", true);
        } // blocking

        else
        {
            anim.SetBool("isRolling", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isBlocking", false);
            anim.SetBool("isHitted", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isDead", false);
        } //anims bool

    }
}
                