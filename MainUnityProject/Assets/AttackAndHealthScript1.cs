using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackAndHealthScript1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    BoxCollider boxCollider;
    public InputAction attackAction;
    public int playerTwoHealth = 5;

    public float hitForce = 1;

    public Rigidbody rb;

    public Rigidbody rb2;

    public CanAttackScript AttackScript;

    public float Cooldown = 2f;

    public float cooldownLeft = 0f;

    public GameObject Player2;

    public GameObject Player2PreFab;

    public int respawnHealth = 5;

    public MiddleScript MiddleScript;
    
    public GameObject PlayerModel2;

    public GameObject Player2Respawn;

    public int respawnsLeft = 2;

    public GameObject markerPreFab;

    public GameObject markerPosition;
    // Update is called once per frame
    void Start()
    {
        attackAction.Enable();
    }
    void Update()
    {
        
        cooldownLeft -= Time.deltaTime;
        
        if (AttackScript.canAttack && attackAction.WasPressedThisFrame() && cooldownLeft <= 0)
        {
            playerTwoHealth -= 1;

            if (transform.eulerAngles.y == 0)
            {
                rb2.AddForce(Vector3.right * hitForce, ForceMode.Impulse);
            }
            else if (transform.eulerAngles.y == 180)
            {
                rb2.AddForce(Vector3.left * hitForce, ForceMode.Impulse);
            }
            
            Instantiate(markerPreFab, markerPosition.transform.position, Quaternion.identity);
            
            //if player1 is facing right, rb.AddForce(Vector3.right * hitForce)
            
            //if player1 is facing left, rb.AddForce(Vector3.left * hitForce)
            cooldownLeft = Cooldown;
        }
        print(playerTwoHealth);
        
        if(playerTwoHealth == 0 && respawnsLeft > 0)
        {
            respawnsLeft -= 1;
            print("Hello");
            PlayerModel2.SetActive(false);
            playerTwoHealth = respawnHealth;
            Player2.transform.position = Player2Respawn.transform.position;
            rb2.MovePosition(Player2Respawn.transform.position);
            PlayerModel2.SetActive(true);
        }
        else if (playerTwoHealth == 0 && respawnsLeft <= 0)
        {
            PlayerModel2.SetActive(false);
        }
        
    }
}