using UnityEngine;

public class WalkSoundPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public AudioSource walkSound;

    public AudioClip footStep;

    public AudioClip attackSound;

    public void PlayFootstepSound()
    {
        walkSound.PlayOneShot(footStep);
    }

    public void PlayAttackSound()
    {
        walkSound.PlayOneShot(attackSound);
    }
}
