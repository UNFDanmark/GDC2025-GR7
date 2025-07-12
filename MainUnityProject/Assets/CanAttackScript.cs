using UnityEngine;

public class CanAttackScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool canAttack = false;
    
    
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            print("attack now");
            canAttack = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            canAttack = false;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
