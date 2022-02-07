using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private Slider SliderVolume;
    [SerializeField] private Toggle LowGraphic;
    [SerializeField] private Toggle MediumGraphic;
    [SerializeField] private Toggle HighGraphic;
    [SerializeField] private bool isFullScreen;

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
