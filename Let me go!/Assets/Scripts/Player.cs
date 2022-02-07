using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource Sound;
    [SerializeField] private KeyCode keyOne;
    [SerializeField] private KeyCode keyTwo;
    [SerializeField] private KeyCode keyStop;
    [SerializeField] private Vector3 moveDirection;

    private int countUnlockedLevels;
    private Vector3 _velocity;

    private void FixedUpdate()
    {
        _velocity = GetComponent<Rigidbody>().velocity;

        if (Input.GetKey(keyOne))
            _velocity += moveDirection;

        if (Input.GetKey(keyTwo))
            _velocity -= moveDirection;

        if (Input.GetKey(keyStop))
            _velocity = new Vector3(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (!Sound.isPlaying)
        {
            if (Input.GetKey(keyOne))
                Sound.Play();

            if (Input.GetKey(keyTwo))
                Sound.Play();
        }

        if (Input.GetKeyUp(keyOne))
            Sound.Stop();

        if (Input.GetKeyUp(keyTwo))
            Sound.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            if (string.IsNullOrEmpty(PlayerPrefs.GetString("SavedLevels")))
                PlayerPrefs.SetString("SavedLevels", "2");
            else
            {
                countUnlockedLevels = int.Parse(PlayerPrefs.GetString("SavedLevels"));

                if (SceneManager.GetActiveScene().buildIndex - 1 == countUnlockedLevels)
                {
                    countUnlockedLevels++;
                    PlayerPrefs.SetString("SavedLevels", countUnlockedLevels.ToString());
                }
            }

            if (SceneManager.GetActiveScene().buildIndex == 16)
                SceneManager.LoadScene(1);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.CompareTag("Barrier"))
        {
            foreach (Activator button in FindObjectsOfType<Activator>())
                button.canPush = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Barrier"))
            foreach (Activator button in FindObjectsOfType<Activator>())
                button.canPush = true;
    }
}
