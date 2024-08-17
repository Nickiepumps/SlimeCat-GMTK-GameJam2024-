using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("PlayerSize")]
    [SerializeField] public Vector2 normalSize = new Vector2(0.044f, 0.044f);
    [SerializeField] public Vector2 mediumSize = new Vector2(0.066f, 0.066f);
    [SerializeField] public Vector2 largeSize = new Vector2(0.099f, 0.099f);
    [SerializeField] public Vector2 veryLargeSize = new Vector2(0.15f, 0.15f);
    [SerializeField] public Vector2 smallSize = new Vector2(0.03f, 0.03f); // Player Small Size
    public int playerSize = 1;

    [Header("Momvement Speed")]
    [SerializeField] private int moveSpeed = 5;
    [SerializeField] private int jumpForce = 50;
    [SerializeField] private int pukeForce = 70;
    [SerializeField] private int foodCount = 0; // Temp Code
    private float moveX;

    [Header("Interaction Radius")]
    [SerializeField] private float groundCheckRadius = 0.6f;
    [SerializeField] private float eatRadius = 0.6f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask eatableLayer;
    
    private bool isGround; // Player is on the ground
    private bool isHitEatObj; // Hit Eatable Object
    private bool isShrinking; // Player Force Shrink
    private bool isPuke;

    private Rigidbody2D playerRB;

    public GameObject eatableObject1; // Temp Code
    public GameObject eatableObject2; // Temp Code
    private void Start()
    {
        playerRB = transform.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // Eatable Object collision check
        isHitEatObj = Physics2D.OverlapCircle(transform.position, eatRadius, eatableLayer);

        // Jump System
        isGround = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

        if(isPuke == true)
        {
            return;
        }

        if(isGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce((Vector2.up * jumpForce), ForceMode2D.Impulse);
        }

        // Walk
        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if(moveX < 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(moveX > 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = false;
        }

        if(Input.GetKeyDown(KeyCode.Q) && foodCount > 0)
        {
            Puke();
        }

        ScaleUp();
        ForceScaleDown();
    }
    private void FixedUpdate()
    {
        if (isPuke == false)
        {
            playerRB.velocity = new Vector2(moveX, playerRB.velocity.y);
        }
    }
    private void ScaleUp()
    {
        if(isHitEatObj == true && Input.GetKeyDown(KeyCode.E))
        {
            //Destroy(eatableObject);       
            groundCheckRadius = 1.5f;
            playerSize++;
            foodCount++;
            isShrinking = false;
            Debug.Log("Meow");
            if(playerSize == 2)
            {
                transform.localScale = mediumSize;
            }
            else if(playerSize == 3)
            {
                transform.localScale = largeSize;
            }
            else if(playerSize == 4)
            {
                transform.localScale = veryLargeSize;
            }
        }
    }
    private void Puke()
    {
        isPuke = true;
        playerSize--;
        if (foodCount == 3)
        {
            StartCoroutine(Dash());
            transform.localScale = largeSize;
        }
        else if (playerSize == 2)
        {
            StartCoroutine(Dash());
            transform.localScale = mediumSize;
        }
        else if (playerSize == 1)
        {
            StartCoroutine(Dash());
            transform.localScale = normalSize;
        }
        foodCount--;
    }
    private void ForceScaleDown()
    {
        if(isHitEatObj == false && Input.GetKey(KeyCode.LeftControl) && isShrinking == false && foodCount == 0 && playerSize == 1)
        {
            transform.localScale = new Vector2(0.0279f, 0.0279f);
            isShrinking = true;
            Debug.Log("Meow");
        }
        else if(isHitEatObj == false && Input.GetKeyUp(KeyCode.LeftControl) && isShrinking == true && foodCount == 0)
        {
            transform.localScale = new Vector2(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f);
            isShrinking = false;
        }
    }
    private IEnumerator Dash()
    {
        isPuke = true;
        playerRB.gravityScale = 0;

        if(transform.GetComponent<SpriteRenderer>().flipX == true)
        {
            playerRB.AddForce(Vector2.left * pukeForce, ForceMode2D.Impulse);
        }
        else
        {
            playerRB.AddForce(Vector2.right * pukeForce, ForceMode2D.Impulse);
        }
        
        //playerRB.velocity = new Vector2(moveX * pukeForce, playerRB.velocity.y);
        yield return new WaitForSeconds(0.05f);
        playerRB.gravityScale = 1;
        isPuke = false;
    }
}
