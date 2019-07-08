using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Con_sound : MonoBehaviour
{
    public AudioSource Audio_Bg;
    public Slider musicSd;
    public Toggle Toggle_Music;

    public void con_sound()
    {
        Audio_Bg.volume = musicSd.value;
    }

    public void  tog_sound()
    {
        if (Toggle_Music.isOn == false)
        {
            Audio_Bg.Stop();
        }
        else
        {
            Audio_Bg.Play();
        }
    }

    void Update()
    {
  
    }
}
