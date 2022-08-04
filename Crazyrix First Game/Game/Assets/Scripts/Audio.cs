using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource bitcoinFX;
    // Start is called before the first frame update
   public void playAudio()
    {
        bitcoinFX.Play(0);
        
    }
    public void stopAudio()
    {
        bitcoinFX.Stop();
    }
}
