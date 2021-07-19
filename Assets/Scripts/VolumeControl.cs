using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    public Slider slider;
    public void Start()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = slider.value;
        Save();
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
    }
    private void Load()
    {
        PlayerPrefs.GetFloat("Volume");
    }
}

