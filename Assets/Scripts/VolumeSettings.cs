using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioMixer Mixer;
    [SerializeField] private Slider MasterSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setVolume()
    {
        float vol = MasterSlider.value;
        Mixer.SetFloat("MasterVolume", vol);
    }
}
