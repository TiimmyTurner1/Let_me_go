using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int countUnlockedLevels;
    public AudioSource Sound;

    [SerializeField] KeyCode keyOne;
    [SerializeField] KeyCode keyTwo;
    [SerializeField] KeyCode keyStop;
    [SerializeField] Vector3 moveDirection;    
    
    private void FixedUpdate()
    {
        if (Input.GetKey(keyOne))
        {
            GetComponent<Rigidbody>().velocity += moveDirection;    
        }        
        if (Input.GetKey(keyTwo))
        {
            GetComponent<Rigidbody>().velocity -= moveDirection;  
        }        
        if (Input.GetKey(keyStop))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);            
        }
    }

    private void Update()
    {
        if (!Sound.isPlaying)
        {
            if (Input.GetKey(keyOne))
            {
                Sound.Play();
            }
            if (Input.GetKey(keyTwo))
            {
                Sound.Play();
            }
        }        
        if (Input.GetKeyUp(keyOne))
        {
            Sound.Stop();
        }
        if (Input.GetKeyUp(keyTwo))
        {
            Sound.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            if (string.IsNullOrEmpty(PlayerPrefs.GetString("SavedLevels")))
            {
                PlayerPrefs.SetString("SavedLevels", "2");
            }
            else
            {
                countUnlockedLevels = int.Parse(PlayerPrefs.GetString("SavedLevels"));
                if (SceneManager.GetActiveScene().buildIndex - 1 == countUnlockedLevels)
                {
                    countUnlockedLevels++;
                    PlayerPrefs.SetString("SavedLevels", countUnlockedLevels.ToString());
                }
            }
            if(SceneManager.GetActiveScene().buildIndex==16)
                SceneManager.LoadScene(1);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);            
        }
        if (this.CompareTag("Player") && other.CompareTag("Barrier"))
        {
            foreach(Activator button in FindObjectsOfType<Activator>())
            {
                button.canPush = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Barrier"))
        {
            foreach (Activator button in FindObjectsOfType<Activator>())
            {
                button.canPush = true;
            }
        }
    }
}
