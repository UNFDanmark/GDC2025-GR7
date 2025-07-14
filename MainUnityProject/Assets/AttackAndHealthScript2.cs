using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackAndHealthScript2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    BoxCollider boxCollider;
    public InputAction attackAction;
    public int playerOneHealth = 5;

    public float hitForce = 1;

    public Rigidbody rb;

    public Rigidbody rb2;

    public CanAttackScript2 AttackScript2;
    
    public float Cooldown = 2f;

    public float cooldownLeft = 0f;

    public GameObject Player1;

    public int respawnHealth = 5;

    public GameObject Player1PreFab;

    public MiddleScript MiddleScript;

    public GameObject PlayerModel;

    public GameObject Player1Respawn;

    public int respawnsLeft = 2;

    // Update is called once per frame
    void Start()
    {
        attackAction.Enable();
    }
    void Update()
    {
        
        cooldownLeft -= Time.deltaTime;
        
        if (AttackScript2.canAttack && attackAction.WasPressedThisFrame() && cooldownLeft <= 0)
        {
            playerOneHealth -= 1;
            if (transform.eulerAngles.y > 90)
            {
                rb2.AddForce(Vector3.right * hitForce, ForceMode.Impulse);
            }
            else if (transform.eulerAngles.y < 90)
            {
                rb2.AddForce(Vector3.left * hitForce, ForceMode.Impulse);
            }
            
            //if player1 is facing right, rb.AddForce(Vector3.right * hitForce)
            
            //if player1 is facing left, rb.AddForce(Vector3.left * hitForce)
            cooldownLeft = Cooldown;
        }
        print(playerOneHealth);
        
        if (playerOneHealth == 0 && respawnsLeft > 0)
        {
            respawnsLeft -= 1;
            print("Hello");
            PlayerModel.SetActive(false);
            playerOneHealth = respawnHealth;
            Player1.transform.position = Player1Respawn.transform.position;
            rb2.MovePosition(Player1Respawn.transform.position);
            PlayerModel.SetActive(true);
        }
        else if (playerOneHealth == 0 && respawnsLeft <= 0)
        {
            PlayerModel.SetActive(false);
        }
    }
}