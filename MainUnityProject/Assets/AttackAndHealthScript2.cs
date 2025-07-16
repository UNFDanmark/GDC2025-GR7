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
        
        if (AttackScript2.canAttack && attackAction.WasPressedThisFrame() && cooldownLeft <= 0)
        {
            CameraShakeScript.DoShake(shakeDuration);
            
            playerOneHealth -= 1;
            
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
            playerOneHealth = respawnHealth;
            Player1.transform.position = Player1Respawn.transform.position;
            rb2.MovePosition(Player1Respawn.transform.position);
            PlayerModel.SetActive(true);
        }
        else if (playerOneHealth == 0 && respawnsLeft <= 0)
        {
            PlayerModel.SetActive(false);
            BlueHeart3.SetActive(false);
            print("before timer");
            
            if(!hasAlreadySetFadeTime)
            {
                fadeToWinScreenTimeLeft = fadeToWinScreenTime;
                hasAlreadySetFadeTime = true;
                RedWin = true;
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
    }
}