using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Text textSound;
    private float sound;

    // Start is called before the first frame update
    void Start()
    { 
        sound = PlayerPrefs.GetFloat("Sound");
        if (sound == 1f)
        {
            textSound.text = "Sound: On";
        }
        else
        {
            textSound.text = "Sound: Off";
        }

    }
    public void volumeClick()
    {
        sound = PlayerPrefs.GetFloat("Sound");
        if (sound == 1f)   {
            PlayerPrefs.SetFloat("Sound", 0f);
            textSound.text = "Sound: Off";
        }
        else {
            PlayerPrefs.SetFloat("Sound", 1f);
            textSound.text = "Sound: On";
        }
    }
}
