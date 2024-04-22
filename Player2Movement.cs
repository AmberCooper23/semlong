using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Movement : MonoBehaviour //Same as player one except the projectile mechanic is not included
{
    private GameObject Player2;
    private Rigidbody2D rb2;

    Keyboard key = Keyboard.current;

    public float JumpHeight = 2f;  //Adjust these to be the same as player1
    public float MovementSpeed = 300f;
    public float JumpTimer = 1f;

    private bool OnGround;

  ////  public float groundCheckRadius = 0.1f;
///public LayerMask groundLayer;
  ///  public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        Player2 = this.gameObject;
        rb2 = GetComponent<Rigidbody2D>();


        OnGround = true;
    }
    private void Movement()
    {
        Vector2 Input = new Vector2();

        if (key.upArrowKey.isPressed && OnGround == true)
        {
            rb2.AddForce(JumpHeight * Vector2.up);



        }

        if (key.leftArrowKey.isPressed)
        {
            Input += Vector2.left;
        }

        if (key.rightArrowKey.isPressed)
        {
            Input += Vector2.right;
        }

        

        Input = Input.normalized;
        rb2.velocity = Input * MovementSpeed * Time.deltaTime;


    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        OnGround = true;


    }

  //////  void FixedUpdate()
   //// {
     //   Vector2 position = rb2.position;
      ///  position.y -= groundCheckRadius;
      //  Collider2D hit = Physics2D.OverlapPoint(position, groundLayer);
     ///   isGrounded = hit != null;
      //  if (isGrounded)
      //  {
            // Prevent the object from moving through the platform
      //      rb2.velocity = new Vector2(rb2.velocity.x, 0);
      //  }
  //  }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround = false;
    }
}
