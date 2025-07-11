using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 1f;
    Rigidbody rb;
    public InputAction moveAction;
    public float gravity = 1f;
    public BoxCollider BoxCollider;
    bool grounded = true;
    void Start()
    {
        moveAction.Enable();

        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        else
        {
            
        }
        
    }


    // Update is called once per frame
    void Update()
    {
    
        float moveInput = moveAction.ReadValue<float>();

        Vector3 newVelocity = rb.linearVelocity;
        
        if (grounded == true)
        {
            
        }
        else
        {
            
        }

        newVelocity.x = moveInput * speed;
        rb.linearVelocity = newVelocity;

        
    }
}
