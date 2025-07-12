using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackAndHealthScript1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    BoxCollider boxCollider;
    bool canAttack = false;
    public InputAction attackAction;
    public int playerTwoHealth = 5;
    void Start()
    {
        attackAction.Enable();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            canAttack = true;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (canAttack == true && attackAction.WasPressedThisFrame())
        {
            playerTwoHealth -= 1;
        }
        print(playerTwoHealth);
    }
}