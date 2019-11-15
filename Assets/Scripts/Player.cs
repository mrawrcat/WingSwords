//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Player : MonoBehaviour
//{
//    public float speed, jumpforce, jumptime, groundtime, checkradius, magneton;
//    public Transform groundcheck;
//    public LayerMask whatIsGround;
//    public bool isjump, onSurface, isGrounded, bodyControl;
//    public GameObject magnet;
//    private Rigidbody2D rb2d;
//    private Animator anim;
//    private float jumpcounter, groundedcounter;
//    private float moveInputX;
//    private HoverUIListener UIListener;
    
//    public bool jumpsfx;
//    public Vector2 startPos;
//    public Vector2 direction;
//    public bool directionChosen;
//    public AudioSource jumpsound;
    
//    // Start is called before the first frame update
//    void Start()
//    {
//        rb2d = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//        UIListener = FindObjectOfType<HoverUIListener>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (bodyControl)
//        {
//            JumpCheck();
//            TouchJumpCheck();
//        }
//        //JumpCheck();
//        GroundedDetectAnim();
//        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatIsGround);
//        magneton -= Time.deltaTime;
//        if(magneton > 0)
//        {
//            magnet.SetActive(true);
//        }
//        else
//        {
//            magnet.SetActive(false);
//        }

//        if (GameManager.manager.dead)
//        {
//            this.GetComponent<Collider2D>().isTrigger = true;
//        }
//        else
//        {
//            this.GetComponent<Collider2D>().isTrigger = false;
//        }

//        //if (directionChosen)
//        //{
//        //    // Something that uses the chosen direction...
//        //}
//    }
//    //private void FixedUpdate()
//    //{
//    //    if (bodyControl)
//    //    {
//    //        if (!onSurface)
//    //        {
//    //            moveInputX = Input.GetAxis("Horizontal");
//    //            rb2d.velocity = new Vector2(moveInputX * speed, rb2d.velocity.y);
//    //        }

//    //        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatIsGround);

//    //        if (moveInputX != 0 && isGrounded)
//    //        {
//    //            anim.SetBool("isRunning", true);

//    //        }
//    //        else if (moveInputX == 0 && isGrounded)
//    //        {
//    //            anim.SetBool("isRunning", false);
//    //        }
//    //    }
        
//    //}

//    void JumpCheck()
//    {
//        if (Input.GetKeyUp(KeyCode.Space))
//        {
//            isjump = false;
//        }
//        if (isGrounded)
//        {
//            groundedcounter = groundtime;
//            isjump = false;
//            //jumpsfx = true;
//        }
//        if (!isGrounded)
//        {
//            groundedcounter -= Time.deltaTime;
//        }
//        if ((Input.GetKey(KeyCode.Space) && groundedcounter > 0))
//        {
            
//            rb2d.velocity = Vector2.up * jumpforce;
//            isjump = true;
//            jumpcounter = jumptime;
            
//        }
//        if (Input.GetKey(KeyCode.Space) && isjump == true)
//        {
//            if (jumpcounter > 0)
//            {
//                rb2d.velocity = Vector2.up * jumpforce;
//                jumpcounter -= Time.deltaTime;
//            }
//            else
//            {
//                isjump = false;
//            }
//        }

//        if (Input.GetKey(KeyCode.Space) && isGrounded)
//        {
//            if (!jumpsound.isPlaying)
//            {
//                jumpsound.Play();
//                Debug.Log("sound played");
//            }
//            Debug.Log("jump sound played");
//        }


//    }
//    void JumpCheck2()
//    {

//        if (Input.GetKeyUp(KeyCode.Space) || isGrounded)
//        {
//            isjump = false;
//        }
//        if ((Input.GetKey(KeyCode.Space) && isGrounded))
//        {
//            rb2d.velocity = Vector2.up * jumpforce;
//            isjump = true;
//            jumpcounter = jumptime;
//        }
//        if (Input.GetKey(KeyCode.Space) && isjump == true)
//        {
//            if (jumpcounter > 0)
//            {
//                rb2d.velocity = Vector2.up * jumpforce;
//                jumpcounter -= Time.deltaTime;
//            }
//            else
//            {
//                isjump = false;
//            }
//        }
//    }

//    void TouchJumpCheck()
//    {
//        if (isGrounded)
//        {
//            groundedcounter = groundtime;
//            isjump = false;
//        }
//        if (!isGrounded)
//        {
//            groundedcounter -= Time.deltaTime;
//        }
        
//        if (Input.touchCount > 0)
//        {
           
//            Touch touch = Input.GetTouch(0);

//            switch (touch.phase)
//            {
//                // Record initial touch position.
//                case TouchPhase.Began:


//                    startPos = touch.position;
//                    directionChosen = false;

//                    if (isGrounded)
//                    {
//                        if (!jumpsound.isPlaying)
//                        {
//                            jumpsound.Play();
//                            Debug.Log("sound played");
//                        }
//                    }

//                    Debug.Log("touch began");
//                    break;

//                case TouchPhase.Stationary:

//                    if (groundedcounter > 0)
//                    {
//                        rb2d.velocity = Vector2.up * jumpforce;
//                        isjump = true;
//                        jumpcounter = jumptime;
//                    }
//                    if (isjump == true)
//                    {
//                        if (jumpcounter > 0)
//                        {
//                            rb2d.velocity = Vector2.up * jumpforce;
//                            jumpcounter -= Time.deltaTime;
//                        }
//                        else
//                        {
//                            isjump = false;
//                        }
//                    }
//                    if (isGrounded)
//                    {
//                        if (!jumpsound.isPlaying)
//                        {
//                            jumpsound.Play();
//                            Debug.Log("sound played");
//                        }
//                    }


//                    directionChosen = false;


//                    Debug.Log("touch stay");
//                    break;

//                // Determine direction by comparing the current touch position with the initial one.
//                case TouchPhase.Moved:
//                    direction = touch.position - startPos;

//                    break;

//                // Report that a direction has been chosen when the finger is lifted.
//                case TouchPhase.Ended:
//                    directionChosen = true;
//                    Debug.Log("touch ended");
//                    isjump = false;
//                    break;
//            }
            
            

//        }

//        if (directionChosen)
//        {
//            // Something that uses the chosen direction...
//        }
//    }
//    void GroundedDetectAnim()
//    {
//        if (!isGrounded)
//        {
//            anim.SetBool("isJumping", true);
//        }
//        else
//        {
//            anim.SetBool("isJumping", false);
//        }
//    }
    
    
//}
