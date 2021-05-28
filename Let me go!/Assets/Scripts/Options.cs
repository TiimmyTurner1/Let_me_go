using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
using UnityEngine.Audio; 

public class Options : MonoBehaviour
{
    public Slider SliderVolume;
    public Toggle LowGraphic;
    public Toggle MediumGraphic;
    public Toggle HighGraphic;
    public bool isFullScreen;

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
    public void Volume()
    {
        AudioListener.volume = SliderVolume.value;
    }

    public void Graphics()
    {
        if (LowGraphic.isOn)
            QualitySettings.SetQualityLevel(1);
        if (MediumGraphic.isOn)
            QualitySettings.SetQualityLevel(2);
        if (HighGraphic.isOn)
            QualitySettings.SetQualityLevel(3);

    }
   
}
