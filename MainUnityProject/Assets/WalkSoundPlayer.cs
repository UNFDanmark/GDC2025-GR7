using UnityEngine;

public class WalkSoundPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public AudioSource walkSound;

    public AudioClip footStep;

    public void PlayFootstepSound()
    {
        walkSound.PlayOneShot(footStep);
    }
}
