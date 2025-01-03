using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 15f;
   
    public Vector3 velocity;

    public float gravity = -30f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public float roofDistance = 0.5f;
    public LayerMask groundMask;
    public bool groundSphere;

    public bool isGrounded;
    public Transform roofCheck;
    public bool isRoofed;



    public float timeToJump = 0.15f;
    public IEnumerator co;
    public bool stopped = false;
    public bool groundedStop;
    public bool check;



    public float coyoteTime = 0.15f;
    public float coyoteTimeHolder = 0.35f;
    //Coyote Jump var

    public float jumpTime = 0.35f;
    public float jumpTimeCounter = 0.35f;

    public bool jumpCancel;
    public bool isJumping;
    public bool notInShop = true;

    public bool canMove = true;

    public bool landed, aired;
    public bool roofed, notRoofed;
    // bools to make sound effects play, so when both of them are true when they need to be

    public float jumpPadBounceness = 120;
    public float jumpPadBouncenessSmall = 30;
    // Use this value to change how much hight player gets from bounce pads

    // public Animator g_Animator;

    public DashSlider ds;
    public float dashSpeed, dashBarMaxTime = 1, dashBarCurrentTime, dashRecoverySpeed, dashDuration;
    public bool obtainedDash, canDash, resetDash, dashing, canJump;


    public float x, z;
    public float speedEnded;
    public bool mouseHit;
    public float zero = 0;

    public Transform checkPoint;
    public bool gameStart;
    public CanvasGroup cgUI;
    public GameObject GameplayUI;

    public Animator runningManAnimator;
    public Animation running;
    public bool hasTouchedGround;
    public GameObject roofChecker, groundChecker, slopeChecker;
    public float slopeDownSpeed;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        

        if (canDash)
        {
            ds = GameObject.FindGameObjectWithTag("DashSlider").GetComponent<DashSlider>();
            GameplayUI = GameObject.FindGameObjectWithTag("GamePlayUI");


            dashBarCurrentTime = dashBarMaxTime;
            ds.SetMaxTime(dashBarMaxTime);

            cgUI = GameplayUI.GetComponent<CanvasGroup>();

           
            cgUI.alpha = 0;

            if (PlayerPrefs.GetInt("GiveDash", 0) == 1)
            {
                obtainedDash = true;
                canDash = true;

            }


            if (!obtainedDash)
            {
                ds.gameObject.SetActive(false);


            }
            else
            {
                canDash = true;
            }
        }
        gameStart = true;
    }

    public void OnSlope()
    {

        velocity.y = -slopeDownSpeed;

    }  
    
    public void NotOnSlope()
    {
       
        velocity.y = -2;
      
    }

    public void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart && obtainedDash && canDash)
        {
            cgUI.alpha += 1 * Time.deltaTime;


        }



        //if (canMove)
        {
            /*
            groundSphere = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if ((controller.collisionFlags & CollisionFlags.Below) != 0 && groundSphere)
            {

                isGrounded = true;
                runningManAnimator.enabled = true;
                hasTouchedGround = true;
            }
            else
            {
                isGrounded = false;
                runningManAnimator.enabled = false;
            }
            // roundabout way to check if player is on ground and doesn't care about hitboxes, this is to prevent when the player is on a corner and isnt considered on the ground
            */ // this is all the working ground tech, just seeing if detectGroundObject is working

          //  isRoofed = Physics.CheckSphere(roofCheck.position, roofDistance, groundMask);

           // isRoofed = roofChecker.


            if((controller.collisionFlags & CollisionFlags.Above) != 0)
            {
                isRoofed = true;



            }


            if (isGrounded && velocity.y < 0)
            {

              //  velocity.y = -2f;
                // g_Animator.SetBool("Grounded", true);

                coyoteTime = coyoteTimeHolder;
                isRoofed = false;
                landed = true;
                notRoofed = true;

                if (dashBarCurrentTime < dashBarMaxTime && canDash)
                {
                    dashBarCurrentTime += dashRecoverySpeed * Time.deltaTime;
                    if (dashBarCurrentTime > dashBarMaxTime)
                    {
                        dashBarCurrentTime = dashBarMaxTime;
                    }

                    ds.SetTime(dashBarCurrentTime);


                }


            }

            if (isRoofed && hasTouchedGround)
            {
                velocity.y = -2f;
                jumpTimeCounter = 0;
                hasTouchedGround = false;
            }


            if (!isGrounded)
            {
                // g_Animator.SetBool("Grounded", false);
                landed = false;
                aired = true;
                coyoteTime -= 1 * Time.deltaTime;
            }

            // this is to ground the player and gives velocity downwards to prevent floating, it also resets jump time, and gun animations






            if (canMove)
            {
                Move();
                controller.Move(move.normalized * speed * Time.deltaTime);
            }

            if (!dashing)
            {
                
            }
            // how the player moves


            if (isGrounded && !dashing)
            {
                x = Input.GetAxisRaw("Horizontal");
                z = Input.GetAxisRaw("Vertical");
            }



            if (!isGrounded && !dashing)
            {
                x = Input.GetAxisRaw("Horizontal") / .75f;
                z = Input.GetAxisRaw("Vertical") / .75f;
            }


            // when player moves, they gain speed and gun animation happenes


            // prevents player from moving too fast or too slow



            // Slows the players speed with gun animation

            if (canJump)
            {
                JumpStuff();
            }

            // Jumping, Coyote jump, holding jump

            if (obtainedDash)
            {
                if (Input.GetKeyDown(KeyCode.E) && canDash && !resetDash && dashBarCurrentTime >= dashBarMaxTime)
                {
                    canDash = false;
                    dashing = true;

                    dashBarCurrentTime = 0;
                    ds.SetTime(dashBarCurrentTime);
                    StartCoroutine(DashCancel());
                }

            }




            if (dashing)
            {
                if ((x > 0 || x < 0) || (z > 0 || z < 0))
                {

                }
                else
                {
                    z = 1;
                }
                controller.Move(move.normalized * dashSpeed * Time.deltaTime);
                velocity.y = 0;

                // change this to prevent falling down

                /*Vector3 Mover = transform.forward * dashSpeed * z;
                  velocity.z = dashSpeed;
                controller.Move(Mover);
                velocity.y = 0;
                velocity.x = 0;
                x = 0;
                */

                if ((controller.collisionFlags & CollisionFlags.Sides) != 0)
                {
                    DashStop();
                    velocity.y = 0;
                    Debug.Log("Collided sides");
                }
            }


            if (Input.GetKeyDown(KeyCode.F))
            {

                Debug.Log(velocity.x);
            }


            if (!canMove)
            {
                if (velocity.y < 3)
                {
                    canMove = true;
                }
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            // gravity and moving the character 


        }

    }

    public void Move()
    {
        move = transform.right * x + transform.forward * z;
    }
    public void JumpStuff()
    {
        if (Input.GetButtonDown("Jump") && !jumpCancel && notInShop)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            coyoteTime = 0;
            slopeChecker.SetActive(false);
            isJumping = true;
            jumpTimeCounter = jumpTime;
            Debug.Log("Pressed Jump");

            // FindObjectOfType<AudioManager>().Play("Jump");

        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                coyoteTime = 0;
                slopeChecker.SetActive(false);
                if (jumpTimeCounter > 0)
                {
                    jumpTimeCounter -= Time.deltaTime;
                }
                //   Debug.Log("Holding Jump");
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log("Let go of Jump");
            isJumping = false;
            jumpTimeCounter = 0;
            coyoteTime = 0;
        }



        if (coyoteTime <= 0)
        {
            jumpCancel = true;
        }
        else
        {
            jumpCancel = false;
        }



    }

    public void Jump()
    {
        velocity = Vector3.zero;
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
       // canMove = false;
    }

    private void OnTriggerEnter(Collider other)
    {
    }

    IEnumerator DashCancel()
    {
        Debug.Log("DashCancel");
        if (canDash == true)
        {
            yield break;
        }
        yield return new WaitForSeconds(dashDuration);
        DashStop();

    }

    IEnumerator DashWait()
    {
        //resetDash = true;
        canDash = true;
        yield return new WaitForSeconds(dashDuration);




        //resetDash = false;
        //Debug.Log("DashWait");


    }

    void DashStop()
    {
        if (!resetDash)
        {
            Debug.Log("DashStop!");
            dashing = false;
            StartCoroutine(DashWait());
            velocity.z = 0;

        }

    }
}
