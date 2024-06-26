using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    FullScreenMode screenMode;
    public Toggle screenBtn;
    public AudioMixer masterMixer;
    public Slider audioSlider;

    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

    public void FullScreenBtn(bool isOn)
    {
        if (isOn == true)
        {
            Debug.Log("전체화면");
            Screen.SetResolution(960, 720, FullScreenMode.FullScreenWindow);
        }
        else
        {
            Debug.Log("창 화면");
            Screen.SetResolution(960, 720, FullScreenMode.Windowed);
        }
    }
}
