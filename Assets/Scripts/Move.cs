using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
   
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer = true;
    private float playerSpeed = 1.0f;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Vector3 moveDirection;
    private Rigidbody _rigidbody;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        groundedPlayer = true;
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        
        if (moveDirection != Vector3.zero)
        {
            gameObject.transform.forward = moveDirection;
        }
        
        //if(!groundedPlayer) playerVelocity.y += gravityValue * Time.deltaTime;
    }

    private void HandleMovement()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(moveDirection * Time.deltaTime * playerSpeed);
    }

    private void HandleJump()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump"))
        {
            if(groundedPlayer) _rigidbody.AddForce(0,Mathf.Sqrt(jumpHeight * -4.0f * gravityValue),0,ForceMode.Impulse);
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
    }
}
