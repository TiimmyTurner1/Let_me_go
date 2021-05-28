using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static string SavedLevels;
    public int countUnlockedLevels;    

    [SerializeField]
    Sprite unlockedIcon;

    [SerializeField]
    Sprite lockedIcon;

    private void Start()
    {        
        SavedLevels = PlayerPrefs.GetString("SavedLevels");
        if (string.IsNullOrEmpty(SavedLevels))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                int numLvl = i + 1;
                #region RenameButtonAndChangeText
                transform.GetChild(i).gameObject.name = numLvl.ToString();
                transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = numLvl.ToString();
                #endregion

                if (i < 1)
                {
                    #region FirstStateBtn
                    transform.GetChild(i).GetComponent<Image>().sprite = unlockedIcon;
                    transform.GetChild(i).GetComponent<Button>().interactable = true;
                    #endregion
                }
                else
                {
                    #region SecondStateBtn
                    transform.GetChild(i).GetComponent<Image>().sprite = lockedIcon;
                    transform.GetChild(i).GetComponent<Button>().interactable = false;
                    #endregion
                }
            }
        }
        else
        {
            countUnlockedLevels = int.Parse(SavedLevels);
            for (int i = 0; i < transform.childCount; i++)
            {
                int numLvl = i + 1;
                #region RenameButtonAndChangeText
                transform.GetChild(i).gameObject.name = numLvl.ToString();
                transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = numLvl.ToString();
                #endregion

                if (i < countUnlockedLevels)
                {
                    #region FirstStateBtn
                    transform.GetChild(i).GetComponent<Image>().sprite = unlockedIcon;
                    transform.GetChild(i).GetComponent<Button>().interactable = true;
                    #endregion
                }
                else
                {
                    #region SecondStateBtn
                    transform.GetChild(i).GetComponent<Image>().sprite = lockedIcon;
                    transform.GetChild(i).GetComponent<Button>().interactable = false;
                    #endregion
                }
            }
        }
        
    }

    

}
