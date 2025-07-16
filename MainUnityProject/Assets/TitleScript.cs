using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public InputAction startAction;
    
    void Start()
    {
        startAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (startAction.WasPressedThisFrame())
        {
            SceneManager.LoadScene("Programmering");
        }
    }
}
