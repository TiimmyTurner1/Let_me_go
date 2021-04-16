using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
using UnityEngine.Audio; 

public class Options : MonoBehaviour
{
    public bool isOpened = false; //Открыто ли меню
    public float volume = 0; //Громкость
    public int quality = 0; //Качество
    public bool isFullScreen; //Полноэкранный режим
    public AudioMixer audioMixer; //Регулятор громкости
    public Dropdown resolutionDropdown; //Список с разрешениями для игры
    private Resolution[] resolutions; //Список доступных разрешений
    private int currResolutionIndex = 0; //Текущее разрешение

    public void AudioVolume(float sliderValue)
    {
        audioMixer.SetFloat("masterVolume", sliderValue);
    }

    public void ChangeResolution(int index) //Изменение разрешения
    {
        currResolutionIndex = index;
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void ChangeQuality(int index) //Изменение качества
    {
        quality = index;
    }
}
