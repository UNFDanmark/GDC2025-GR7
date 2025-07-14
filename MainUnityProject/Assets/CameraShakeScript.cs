using Unity.Cinemachine;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    
    
    float timeToDisableCameraShake;
    
    public CinemachineBasicMultiChannelPerlin CameraNoise;
    
    public float AmplitudeChange = 1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToDisableCameraShake > 0)
        {
            timeToDisableCameraShake -= Time.deltaTime;
        }
        else
        {
            CameraNoise.AmplitudeGain = 0;
        }
    }

    public void DoShake(float shakeTime)
    {
        timeToDisableCameraShake = shakeTime;
        CameraNoise.AmplitudeGain = AmplitudeChange;
    }
}
