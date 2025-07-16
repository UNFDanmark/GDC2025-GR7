using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevelPhysics;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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

    public CinemachineBasicMultiChannelPerlin CameraNoise;
    
    public float shakeDuration = 1f;

    float timeToDisableCameraShake;

    public CameraShakeScript CameraShakeScript;
    
    public GameObject Player1VictoryScreen;

    public float fadeToWinScreenTime = 3f;

    float fadeToWinScreenTimeLeft;

    bool hasAlreadySetFadeTime = false;

    public Volume BlueVignette;

    public bool BlueWin;

    public InputAction restartAction;

    public Animator Animator;

    public GameObject RedHeart1;

    public GameObject RedHeart2;

    public GameObject RedHeart3;

    public GameObject fiveOfFive;
    
    public GameObject fourOfFive;

    public GameObject threeOfFive;

    public GameObject twoOfFive;

    public GameObject oneOfFive;

    public GameObject zeroOfFive;

    public AudioSource AudioSource;
    
    public float hitTimer = 0.1f;

    float hitTimerLeft;

    public SkinnedMeshRenderer MeshRenderer;

    public Material HitMark;

    bool hitTimerHasSet = false;

    public Material cat;

    public AttackAndHealthScript2 AttackAndHealthScript2;

    
    
    
    // Update is called once per frame
    void Start()
    {
        attackAction.Enable();
        restartAction.Enable();
    }
    void Update()
    {
        if (BlueWin == true)
        {
            BlueVignette.weight = Mathf.Lerp(BlueVignette.weight, 1, Time.deltaTime);
        }
        
        cooldownLeft -= Time.deltaTime;
        
        fadeToWinScreenTimeLeft -= Time.deltaTime;
        
        hitTimerLeft -= Time.deltaTime;
        
        Material[] mats = MeshRenderer.materials;
        if (hitTimerLeft <= 0)
        {
            mats[0] = cat;
        }
        
        if (AttackScript.canAttack && attackAction.WasPressedThisFrame() && cooldownLeft <= 0)
        {
            CameraShakeScript.DoShake(shakeDuration);
            
            Animator.SetTrigger("Attack");
            
            playerTwoHealth -= 1;
            
            
            hitTimerLeft = hitTimer;
            mats[0] = HitMark;
            
            
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
            
            oneOfFive.SetActive(false);
            zeroOfFive.SetActive(true);
            
            playerTwoHealth = respawnHealth;
            Player2.transform.position = Player2Respawn.transform.position;
            rb2.MovePosition(Player2Respawn.transform.position);
            PlayerModel2.SetActive(true);
            
        }
        else if (playerTwoHealth == 0 && respawnsLeft <= 0)
        {
            PlayerModel2.SetActive(false);
            RedHeart3.SetActive(false);
            
            oneOfFive.SetActive(false);
            zeroOfFive.SetActive(true);

            Player2.SetActive(false);

            if(!hasAlreadySetFadeTime)
            {
                fadeToWinScreenTimeLeft = fadeToWinScreenTime;
                hasAlreadySetFadeTime = true;
                BlueWin = true;
                AudioSource.Play();
            }
            if (fadeToWinScreenTimeLeft <= 0)
            {
                print("timer");
                Player1VictoryScreen.SetActive(true);
            }
        }
        
        if (restartAction.WasPressedThisFrame())
        {
            SceneManager.LoadScene("Programmering");
        }

        if (respawnsLeft == 1)
        {
            RedHeart1.SetActive(false);
        }
        else if (respawnsLeft == 0)
        {
            RedHeart2.SetActive(false);
        }

        if (playerTwoHealth == 5)
        {
            fiveOfFive.SetActive(true);
            zeroOfFive.SetActive(false);
        }
        
        if (playerTwoHealth == 4)
        {
            fiveOfFive.SetActive(false);
            fourOfFive.SetActive(true);
        }
        else if(playerTwoHealth == 3)

        {
            fourOfFive.SetActive(false);
            threeOfFive.SetActive(true);
        }
        else if (playerTwoHealth == 2)
        {
            threeOfFive.SetActive(false);
            twoOfFive.SetActive(true);
        }
        else if (playerTwoHealth == 1)
        {
            twoOfFive.SetActive(false);
            oneOfFive.SetActive(true);
        }
        MeshRenderer.materials = mats;
        
    }
}