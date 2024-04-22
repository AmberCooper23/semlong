using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Movement : MonoBehaviour
{
    private GameObject Player1;
    private Rigidbody2D rb1;

    public GameObject spatula;
    GameObject SpatulaObject;

    Keyboard key = Keyboard.current;

    public float JumpHeight = 2f;
    public float MovementSpeed = 300f;
    public float SpatulaSpeed = 15000f;

    private bool OnGround;
    private DirectionCheck direction;

    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        Player1 = this.gameObject;
        rb1 = GetComponent<Rigidbody2D>();


        OnGround = true;

        direction = new DirectionCheck(false,  false,  false, false); 
    }

    private struct DirectionCheck
    {
        public bool Up, Down, Left, Right;

        public DirectionCheck(bool up, bool down, bool left, bool right)
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;

        }

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void FixedUpdate()
    {
        Vector2 position = rb1.position;
        position.y -= groundCheckRadius;
        Collider2D hit = Physics2D.OverlapPoint(position, groundLayer);
        isGrounded = hit != null;
        if (isGrounded)
        {
            // Prevent the object from moving through the platform
            rb1.velocity = new Vector2(rb1.velocity.x, 0);
        }
    }

    private void Movement()
    {
        Vector2 Input = new Vector2(); 

        if (key.wKey.isPressed &&  OnGround == true)
        {
            rb1.AddForce(JumpHeight * Vector2.up);
            direction.Up = true;
            direction.Down = false;
            direction.Left = false;
            direction.Right = false;
                   
        }

        if (key.aKey.isPressed)
        {
            Input += Vector2.left;
            direction.Up = false;
            direction.Down = false;
            direction.Left = true;
            direction.Right = false;
        }

        if (key.dKey.isPressed)
        {
            Input += Vector2.right;
            direction.Up = false;
            direction.Down = false;
            direction.Left = false;
            direction.Right = true;
        }

        if (key.sKey.isPressed)
        {
            direction.Up = false ;
            direction.Down = true;
            direction.Left = false;
            direction.Right = false;

        }

        if (key.shiftKey.isPressed)
        {
            Destroy(SpatulaObject);
            SpatulaGenerator();
        }

        if (key.escapeKey.isPressed)
        {
            Application.Quit();
        }

        Input = Input.normalized;
        rb1.velocity = Input * MovementSpeed * Time.deltaTime;
      
        
    }

    private Vector2 Spatula()
    {
        Vector2 SpatulaDirection = new Vector2();
        Vector2 SpatulaVelocity = new Vector2();


        if (direction.Up)
        {
            SpatulaDirection = Vector2.up;  
        }

        if (direction.Down)
        {
            SpatulaDirection = Vector2.down;
        }

        if (direction.Right)
        {
            SpatulaDirection = Vector2.right;
        }

        if (direction.Left)
        {
            SpatulaDirection = Vector2.left;
        }

        SpatulaVelocity = SpatulaDirection * SpatulaSpeed * Time.deltaTime;

        return SpatulaVelocity;

    }

    private void SpatulaGenerator()
    {
        SpatulaObject = Instantiate(spatula, rb1.position, Quaternion.identity);
       // SpatulaObject.AddComponent<Rigidbody2D>();
        Rigidbody2D rbS = SpatulaObject.GetComponent<Rigidbody2D>();
        Transform transformS = SpatulaObject.transform;
       

        rbS.velocity = Spatula();
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        OnGround = true;
        
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround = false;
    }


}
