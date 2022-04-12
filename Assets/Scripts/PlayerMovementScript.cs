using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{   
    [SerializeField] float runSpd = 10f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
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
    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpd, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;


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
