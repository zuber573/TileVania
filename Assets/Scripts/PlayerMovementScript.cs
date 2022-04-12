using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{   
    [SerializeField] float runSpd = 10f;
    [SerializeField] float jumpSpd = 5f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Run();
        Flipsprt();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value)
    {
        if(!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return;}
        if(value.isPressed)
        {
            myRigidbody.velocity = new Vector2 (0f, jumpSpd);
        }
        
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpd, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        
        myAnimator.SetBool("is_running", playerHasHorizontalSpeed);


    }

    void Flipsprt()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        
        if (playerHasHorizontalSpeed)
        {
        transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        }

    }

    
}
