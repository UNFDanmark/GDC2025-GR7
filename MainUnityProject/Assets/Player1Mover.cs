using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Mover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 1f;
    Rigidbody rb;
    public InputAction moveAction;
    public InputAction jumpAction;
    public float gravity = 1f;
    bool grounded = true;
    public float jumpForce = 10f;
    public float fastFall = 5f;
    public float fallSpeed = 10f;
    public float maxSpeed = 1;
    void Start()
    {
        moveAction.Enable();
        jumpAction.Enable();

        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        print("called");
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        print(grounded);
        
        Vector3 newVelocity = rb.linearVelocity;
        /*
        float moveInput = moveAction.ReadValue<float>();

        

        newVelocity.x = moveInput * speed;
        rb.linearVelocity = newVelocity;
        */
        float moveInput = moveAction.ReadValue<float>();
        
        if (moveInput > 0)
        {
            rb.AddForce(Vector3.right * (speed * Time.deltaTime), ForceMode.Force);
        }
        else if (moveInput < 0)
        {
            rb.AddForce(Vector3.left * (speed * Time.deltaTime) , ForceMode.Force);
        }

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            Vector2 velocityDirection = rb.linearVelocity / rb.linearVelocity.magnitude;
            Vector2 clampedVelocity = velocityDirection * maxSpeed;
            rb.linearVelocity = clampedVelocity;
        }
        
        float jumpInput = jumpAction.ReadValue<float>();

        print(jumpInput);
        
        if (grounded == true && jumpAction.WasPressedThisFrame() && jumpInput > 0)
        {
            rb.AddForce(Vector3.up * jumpForce);
            grounded = false;
            
        }
        else if (grounded == false && jumpInput < 0)
        {
            print("fast fall");
            rb.AddForce(Vector3.down * fastFall);
            
            
        }
        
        // Negative speed increases after reaching max height of the jump
        
        if (newVelocity.y < 0)
        {
            rb.AddForce(Vector3.down * fallSpeed);
        }

        
        
        if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        

    }
}
