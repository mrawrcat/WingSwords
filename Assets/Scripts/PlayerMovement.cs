﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumptime, groundtime, checkradius;
    public Transform groundcheck;
    public LayerMask whatIsGround;
    public bool bodyControl, isjump, onSurface, isInteract, gotKey, usedKey;
    public float moveInputX, moveInputY;
    public bool faceR = true, isGrounded = true, rGravity;
    private Rigidbody2D rb2d;
    private Animator anim;
    private float jumpcounter, groundedcounter;
    //getting hit
    public bool dmgable;
    public float countToDmgable;
    //attack stuff
    public float timeBtwnAtk;
    public float startTimeBtwnAtk;
    public Transform atkpos;
    public float atkRange;
    public LayerMask whatIsEnemies;
    public float dmg;
    public float maxVelocity = 10;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        bodyControl = true;
        isjump = false;
        isInteract = false;
        gotKey = false;
        usedKey = false;

        dmgable = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bodyControl)
        {

            JumpCheck();
            GroundedDetectAnim();
            Slash();
        }


        countToDmgable -= Time.deltaTime;
        if(countToDmgable <= 0)
        {
            dmgable = true;
        }
        
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatIsGround);
        Facing();
        

    }
    void FixedUpdate()
    {
        if (bodyControl)
        {
            if (!onSurface)
            {
                //LR movement
                moveInputX = Input.GetAxis("Horizontal");
                rb2d.velocity = new Vector2(moveInputX * GameManager.manager.speed, rb2d.velocity.y);
            }
            //moveInputY = Input.GetAxis("Vertical");
            //rb2d.velocity = new Vector2(moveInputX, rb2d.velocity.y);
            isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatIsGround);
            anim.SetFloat("Speed", Mathf.Abs(moveInputX));
            anim.SetFloat("Vertical", rb2d.velocity.y);
            Facing();

            if (moveInputX != 0 && isGrounded)
            {
                anim.SetBool("isRunning", true);

            }
            else if (moveInputX == 0 && isGrounded)
            {
                anim.SetBool("isRunning", false);
            }

        }
        else
        {

            //rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity.magnitude, maxVelocity);
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

    }
    void Flip()
    {
        faceR = !faceR;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    void Facing()
    {
        if (faceR && moveInputX < 0)
        {
            Flip();
        }
        else if (!faceR && moveInputX > 0)
        {
            Flip();
        }
    }
    void GroundedDetectAnim()
    {
        if (!isGrounded)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }
    void JumpCheck()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isjump = false;
        }
        if (isGrounded)
        {
            groundedcounter = groundtime;
            isjump = false;
        }
        if (!isGrounded)
        {
            groundedcounter -= Time.deltaTime;
        }
        if ((Input.GetKey(KeyCode.Space) && groundedcounter > 0))
        {
            rb2d.velocity = Vector2.up * GameManager.manager.jumpforce;
            isjump = true;
            jumpcounter = jumptime;
        }
        if (Input.GetKey(KeyCode.Space) && isjump == true)
        {
            if (jumpcounter > 0)
            {
                rb2d.velocity = Vector2.up * GameManager.manager.jumpforce;
                jumpcounter -= Time.deltaTime;
            }
            else
            {
                isjump = false;
            }
        }
        
    }
    void JumpCheck2()
    {

        if (Input.GetKeyUp(KeyCode.Space) || isGrounded)
        {
            isjump = false;
        }
        if ((Input.GetKey(KeyCode.Space) && isGrounded))
        {
            rb2d.velocity = Vector2.up * GameManager.manager.jumpforce;
            isjump = true;
            jumpcounter = jumptime;
        }
        if (Input.GetKey(KeyCode.Space) && isjump == true)
        {
            if (jumpcounter > 0)
            {
                rb2d.velocity = Vector2.up * GameManager.manager.jumpforce;
                jumpcounter -= Time.deltaTime;
            }
            else
            {
                isjump = false;
            }
        }
    }
    void Slash()
    {
        if(timeBtwnAtk <= 0)
        {
            if (Input.GetKey(KeyCode.F))
            {
                timeBtwnAtk = startTimeBtwnAtk;
                Collider2D[] enemiesToDmg = Physics2D.OverlapCircleAll(atkpos.position, atkRange, whatIsEnemies);
                //StartCoroutine(swingSword());
                for (int i = 0; i < enemiesToDmg.Length; i++)
                {
                    rb2d.velocity = new Vector2(0, 0);
                    Vector2 difference = transform.position - enemiesToDmg[i].transform.position;
                    Vector2 differenceNorm = difference.normalized * 10f;
                    rb2d.AddForce(differenceNorm, ForceMode2D.Impulse);
                    enemiesToDmg[i].GetComponent<Breakable>().TakeDmg(dmg);
                    //enemiesToDmg[i].GetComponent<BossHealth>().TakeDmg(dmg);
                    Debug.Log("hit enemy");
                }
            }
            
        }
        else
        {
            timeBtwnAtk -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(swingSword());
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        yield return new WaitForSeconds(.5f);
        enemy.velocity = Vector2.zero;
    }

    void upsideDown()
    {
        rGravity = !rGravity;
        rb2d.gravityScale = rb2d.gravityScale * -1;
        Vector3 scaler = transform.localScale;
        scaler.y *= -1;
        transform.localScale = scaler;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.collider.tag == "Spike")
    //    {
    //        Debug.Log("stepped on spike");
    //        rb2d.AddForce(transform.up * 900f);
    //        rb2d.AddForce(transform.right * -4000f);
    //    }
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Conveyor")
        {
            if(collision.gameObject.GetComponent<SurfaceEffector2D>().speed != 0)
            {
                onSurface = true;
            }
            else
            {
                onSurface = false;
            }
            
            Debug.Log("On Conveyor");
        }
        if(collision.collider.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Conveyor")
        {
            onSurface = false;
            Debug.Log("Off Conveyor");
        }
        if (collision.collider.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
    
    public void startClimbLedge()
    {
        StartCoroutine(ClimbLedge());
    }
    IEnumerator ClimbLedge()
    {
        //anim.SetBool("isClimb", true);
        bodyControl = false;
        transform.position = new Vector2(transform.position.x, transform.position.y);
        rb2d.gravityScale = 0;
        rb2d.velocity = new Vector2(0, 0);
        anim.SetBool("isClimb", true);
        yield return new WaitForSeconds(.5f);
        transform.position = new Vector2(transform.position.x + .5f * transform.localScale.x, transform.position.y + .5f);
        rb2d.gravityScale = 3;
        rb2d.velocity = new Vector2(moveInputX * GameManager.manager.speed, rb2d.velocity.y);
        //anim.SetBool("isClimb", false);
        bodyControl = true;
        yield return null;
    }

    IEnumerator swingSword()
    {
        //anim.SetBool("isSlashing", true);
        yield return new WaitForSeconds(.3f);
        //anim.SetBool("isSlashing", false);
        yield return null;

    }

    public void TakeDmg(float dmg)
    {
        Debug.Log(dmg + " dmg taken");
        GameManager.manager.health -= dmg;
        //StartCoroutine(dmgAnim());
    }

    //IEnumerator dmgAnim()
    //{
    //    anim = GetComponent<Animator>();
    //    anim.SetBool("isHit", true);
    //    yield return new WaitForSeconds(.3f);
    //    anim.SetBool("isHit", false);
    //    yield return null;

    //}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atkpos.position, atkRange);
    }
}
