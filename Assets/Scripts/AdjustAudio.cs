using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AdjustAudio : MonoBehaviour
{
    private DataTesting data;
    public AudioMixer mixer;
    public Slider masterVolume;
    public Slider musicVolume;
    public Slider SFXVolume;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data").GetComponent<DataTesting>();
        masterVolume.value = data.masterVolume;
        musicVolume.value = data.musicVolume;
        SFXVolume.value = data.SFXVolume;
        changeMasterVolume();
        changeMusicVolume();
        changeSFXVolume();
    }

    public void changeMasterVolume()
    {
        data.masterVolume = masterVolume.value;
        mixer.SetFloat("MasterVolume", masterVolume.value);
    }
    public void changeMusicVolume()
    {
        data.musicVolume = musicVolume.value;
        mixer.SetFloat("MusicVolume", musicVolume.value);
    }

    public void changeSFXVolume()
    {
        data.SFXVolume = SFXVolume.value;
        mixer.SetFloat("SFXVolume", SFXVolume.value);
    }
}
