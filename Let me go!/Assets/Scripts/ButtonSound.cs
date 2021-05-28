using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;    
    public AudioClip click;

    
    public void ClickSound()
    {
        audioSource.PlayOneShot(click);        
    }

}
