using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevelManager : MonoBehaviour
{
    public void LoadLevel(int numLvl)
    {
        SceneManager.LoadScene(numLvl);
    }

    public void BackScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ResetLevels()
    {
        PlayerPrefs.DeleteKey("SavedLevels");
    }
}
