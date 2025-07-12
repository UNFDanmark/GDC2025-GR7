using UnityEngine;

public class CanAttackScript2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool canAttack = false;
    
    
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            print("attack now");
            canAttack = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            canAttack = false;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}