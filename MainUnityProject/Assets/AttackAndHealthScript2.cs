using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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
    
    public GameObject markerPreFab;

    public GameObject markerPosition2;
    
    public CinemachineBasicMultiChannelPerlin CameraNoise;
    
    public float shakeDuration = 1f;

    public float AmplitudeChange = 1;
    
    float timeToDisableCameraShake;
    
    public CameraShakeScript CameraShakeScript;

    public GameObject Player2VictoryScreen;

    public float fadeToWinScreenTime = 3f;

    float fadeToWinScreenTimeLeft;

    bool hasAlreadySetFadeTime = false;
    
    public Volume RedVignette;

    public bool RedWin;

    public InputAction restartAction;
    
    public GameObject BlueHeart1;

    public GameObject BlueHeart2;

    public GameObject BlueHeart3;

    public Animator Animator;
    
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

    public Material bird;

    // Update is called once per frame
    void Start()
    {
        attackAction.Enable();
        restartAction.Enable();
    }
    void Update()
    {
        if (RedWin == true)
        {
            RedVignette.weight = Mathf.Lerp(RedVignette.weight, 1, Time.deltaTime);
        }
        
        cooldownLeft -= Time.deltaTime;
        
        fadeToWinScreenTimeLeft -= Time.deltaTime;

        hitTimerLeft -= Time.deltaTime;
        
        Material[] mats = MeshRenderer.materials;
        if (hitTimerLeft <= 0)
        {
            mats[1] = bird;
        }
        
        
        if (AttackScript2.canAttack && attackAction.WasPressedThisFrame() && cooldownLeft <= 0)
        {
            CameraShakeScript.DoShake(shakeDuration);
            
            Animator.SetTrigger("Attack");
            
            playerOneHealth -= 1;
            
            
            hitTimerLeft = hitTimer;
            mats[1] = HitMark;
            
            
            if (transform.eulerAngles.y > 90)
            {
                rb2.AddForce(Vector3.right * hitForce, ForceMode.Impulse);
            }
            else if (transform.eulerAngles.y < 90)
            {
                rb2.AddForce(Vector3.left * hitForce, ForceMode.Impulse);
            }
            
            Instantiate(markerPreFab, markerPosition2.transform.position, Quaternion.identity);
            
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
            
         
            
            oneOfFive.SetActive(false);
            zeroOfFive.SetActive(true);
            
            playerOneHealth = respawnHealth;
            Player1.transform.position = Player1Respawn.transform.position;
            rb2.MovePosition(Player1Respawn.transform.position);
            PlayerModel.SetActive(true);
        }
        else if (playerOneHealth == 0 && respawnsLeft <= 0)
        {
            BlueHeart3.SetActive(false);
            Player1.GetComponent<AttackAndHealthScript1>().attackAction.Disable();
            attackAction.Disable();
            oneOfFive.SetActive(false);
            zeroOfFive.SetActive(true);
            print("before timer");
            
            Player1.SetActive(false);
            
            if(!hasAlreadySetFadeTime)
            {
                fadeToWinScreenTimeLeft = fadeToWinScreenTime;
                hasAlreadySetFadeTime = true;
                RedWin = true;
                AudioSource.Play();
            }
            if (fadeToWinScreenTimeLeft <= 0)
            {
                print("timer");
                Player2VictoryScreen.SetActive(true);
            }
        }

        if (restartAction.WasPressedThisFrame())
        {
            SceneManager.LoadScene("Programmering");
        }
        
        if (restartAction.WasPressedThisFrame())
        {
            SceneManager.LoadScene("Programmering");
        }

        if (respawnsLeft == 1)
        {
            BlueHeart1.SetActive(false);
        }
        else if (respawnsLeft == 0)
        {
            BlueHeart2.SetActive(false);
        }

        if (playerOneHealth == 5)
        {
            fiveOfFive.SetActive(true);
            zeroOfFive.SetActive(false);
        }
        
        if (playerOneHealth == 4)
        {
            fiveOfFive.SetActive(false);
            fourOfFive.SetActive(true);
        }
        else if(playerOneHealth == 3)

        {
            fourOfFive.SetActive(false);
            threeOfFive.SetActive(true);
        }
        else if (playerOneHealth == 2)
        {
            threeOfFive.SetActive(false);
            twoOfFive.SetActive(true);
        }
        else if (playerOneHealth == 1)
        {
            twoOfFive.SetActive(false);
            oneOfFive.SetActive(true);
        }
        
        MeshRenderer.materials = mats;
        
        
    }
}