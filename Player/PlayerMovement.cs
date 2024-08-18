using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("PlayerSize")]
    public Vector2 normalSize = new Vector2(0.2f, 0.2f); // Player normal size (size 1)
    public Vector2 mediumSize = new Vector2(0.4f, 0.4f); // Player medium size (size 2)
    public Vector2 largeSize = new Vector2(0.7f, 0.7f); // Player large size (size 3)
    public Vector2 veryLargeSize = new Vector2(1.2f, 1.2f); // Player largest size (size 4)
    public Vector2 smallSize = new Vector2(0.1f, 0.1f); // Player small size (size 0)
    public int playerSize = 1; // Player default size (Normal size)

    [Header("Momvement Speed")]
    public float walkSpeed = 3f;
    public int jumpForce = 50;
    public int dashForce = 30;
    private float moveX;

    [Header("Interaction Radius")]
    [SerializeField] private float groundCheckRadius = 0.6f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask eatableLayer;

    [Header("Player item lists")]
    private PlayerInventory inventory; // Player inventory

    [Header("Animation")]
    public Animator animator;
    
    private bool isGround; // Player is on the ground
    private bool isShrinking; // Player Force Shrink
    public bool isPuke; // Player is puking
    public bool isEating; // Player is eating

    private Rigidbody2D playerRB;
    private void Start()
    {
        playerRB = transform.GetComponent<Rigidbody2D>();
        inventory = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<PlayerInventory>();
    }
    private void Update()
    {
        // Ground Detection
        isGround = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer) 
            || Physics2D.OverlapCircle(transform.position, groundCheckRadius, eatableLayer);

        if (isPuke == true)
        {
            return;
        }

        // Jump
        if (isGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if(isGround == true)
        {
            animator.SetBool("IsJump", false);
        }
        else
        {
            animator.SetBool("IsJump", true);
        }

        // Walk
        moveX = Input.GetAxis("Horizontal") * walkSpeed;
        if(moveX < 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("IsWalk", true);
        }
        else if(moveX > 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("IsWalk", true);
        }
        else if(moveX == 0)
        {
            animator.SetBool("IsWalk", false);
        }

        // Player Scaling
        ScaleUp();
        ForceScaleDown();

        // Player Eating Object Animation
        if(isEating == true)
        {
            animator.SetBool("IsEat", true);
        }
        else
        {
            animator.SetBool("IsEat", false);
        }
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
        if (playerSize == 2)
        {
            transform.localScale = mediumSize;
        }
        else if (playerSize == 3)
        {
            transform.localScale = largeSize;
        }
        else if (playerSize == 4)
        {
            transform.localScale = veryLargeSize;
        }
    }
    private void ForceScaleDown()
    {
        if(Input.GetKey(KeyCode.LeftControl) && isShrinking == false && inventory.foodCount == 0 && playerSize == 1)
        {
            transform.localScale = smallSize;
            isShrinking = true;
            Debug.Log("Meow");
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl) && isShrinking == true && inventory.foodCount == 0)
        {
            transform.localScale = normalSize;
            isShrinking = false;
        }
    }
    public IEnumerator Dash()
    {
        if (transform.GetComponent<SpriteRenderer>().flipX == true)
        {
            playerRB.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
        }
        else
        {
            playerRB.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(0.5f);
        isPuke = false;
    }
    private void Sprint()
    {

    }
    private void Jump()
    {
        playerRB.AddForce((Vector2.up * jumpForce), ForceMode2D.Impulse);
    }
    private void CancleEat()
    {
        isEating = false;
    }
}
