using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float jumpDelay;
    [SerializeField] Animator playerAnimator;
    AudioManager audioManager;

    Rigidbody2D playerRigidbody;
    BoxCollider2D playerCollider;

    Vector2 playerInput;

    bool isOnGround;
    int jumpCount;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerRigidbody=GetComponent<Rigidbody2D>();
        playerCollider=GetComponent<BoxCollider2D>();

        
    }

    private void Update()
    {
        CheckIsOnGround();

        PlayRunningAnimation();
        FlipSprite();
        PlayJumpingAnimation();

    }
    private void PlayJumpingAnimation()
    {
        if (playerRigidbody.velocity.y > 1)
        {
            playerAnimator.SetBool("isJumping", true);
        }
        else if (playerRigidbody.velocity.y < -1)
        {
            playerAnimator.SetBool("isFalling", true);
        }
    }

    void FixedUpdate()
    {
        playerRigidbody.velocity=new Vector2(playerInput.x*moveSpeed,playerRigidbody.velocity.y);   
    }

    void OnMove(InputValue inputValue)
    {
        playerInput=inputValue.Get<Vector2>();
    }

    void OnJump()
    {
        if (isOnGround && jumpCount == 0)
        {
            jumpCount++;
            playerRigidbody.velocity += new Vector2(playerRigidbody.velocity.x, jumpSpeed);
            audioManager.PlayJumpSound();
            Invoke(nameof(ResetJumpCount), jumpDelay);
        }      
    }

    //void OnReset() 
    //{
    //    audioManager.PlayDeathSound();
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    void ResetJumpCount() 
    {
        jumpCount = 0;
    }

    void CheckIsOnGround()
    {
        isOnGround=playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

        if (isOnGround)
        {
            playerAnimator.SetBool("isJumping", false);
            playerAnimator.SetBool("isFalling", false);

        }
    }

    void FlipSprite()
    {
        if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }

    }

    private void PlayRunningAnimation()
    {
        if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }
    
    }
}
