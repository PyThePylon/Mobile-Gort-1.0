using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider sliderval;


    public void SetVolume()
    {
        audioMixer.SetFloat("MasterVolume", sliderval.value);
    }
}
