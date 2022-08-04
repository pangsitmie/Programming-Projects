using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    public static bool vibrateState ;
    public Toggle vibrateTogle;


    void Start() {
        if (Player.currentVibrateSetting == 1)
            vibrateState = true;
        else
            vibrateState = false;

        vibrateTogle.isOn = vibrateState;
            
        
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void changeVibrateionState()
    {
        
        if (vibrateState == true)
            Player.currentVibrateSetting = 0;
        else
            Player.currentVibrateSetting = 1;
        
    }
}
