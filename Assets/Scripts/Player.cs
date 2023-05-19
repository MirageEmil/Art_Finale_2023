using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float horizontalInput;
    public float jumpForce;

    public bool isOnGround = true;

    public Rigidbody2D playerRB;
    public SpriteRenderer playerSprite;
    public Animator playerAnimator;

    public KeyCode jumpButton = KeyCode.Space;
    public KeyCode danceButton = KeyCode.RightShift;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //flip the sprite if facing left
        if (horizontalInput > 0)
        {
            playerSprite.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            playerSprite.flipX = true;
        }

        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * horizontalInput);

        playerAnimator.SetFloat("isRunning", Mathf.Abs(horizontalInput));

        if (Input.GetKeyDown(jumpButton) && isOnGround)
        {
            isOnGround = false;
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerAnimator.SetBool("isJumping", true);

        }

        if (Input.GetKeyDown(danceButton) && isOnGround)
        {
            playerAnimator.SetBool("isDancing", true);

        }
    }
}
