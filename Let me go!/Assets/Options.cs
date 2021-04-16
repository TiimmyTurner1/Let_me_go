using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
using UnityEngine.Audio; 

public class Options : MonoBehaviour
{
    public bool isOpened = false; //������� �� ����
    public float volume = 0; //���������
    public int quality = 0; //��������
    public bool isFullScreen; //������������� �����
    public AudioMixer audioMixer; //��������� ���������
    public Dropdown resolutionDropdown; //������ � ������������ ��� ����
    private Resolution[] resolutions; //������ ��������� ����������
    private int currResolutionIndex = 0; //������� ����������

    public void AudioVolume(float sliderValue)
    {
        audioMixer.SetFloat("masterVolume", sliderValue);
    }

    public void ChangeResolution(int index) //��������� ����������
    {
        currResolutionIndex = index;
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void ChangeQuality(int index) //��������� ��������
    {
        quality = index;
    }
}
