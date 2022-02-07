using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip click;

    public void ClickSound()
    {
        audioSource.PlayOneShot(click);
    }
}
