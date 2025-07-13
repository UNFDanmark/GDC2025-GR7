using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class MiddleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform Player1;
    public Transform Player2;

    public float minimumPlayerDistance = 1f;
    public float maximumPlayerDistance = 1f;
    public float minimumCameraDistance = 1f;
    public float maximumCameraDistance = 1f;

    public CinemachinePositionComposer cameraComposer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1 != null && Player2 != null)
        {
            Vector3 averagePosition = (Player1.position + Player2.position) / 2f;
            Vector3 newPosition = transform.position;
            newPosition.x = averagePosition.x;
            transform.position = newPosition;
            float playerDistance= Vector3.Distance(Player1.position, Player2.position);
            float cameraDistance = math.remap(minimumPlayerDistance, maximumPlayerDistance, minimumCameraDistance, maximumCameraDistance,
                playerDistance);
        
            cameraComposer.CameraDistance = cameraDistance;

        }
    }
}
