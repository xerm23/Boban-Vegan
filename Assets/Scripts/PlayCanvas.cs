using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayCanvas : MonoBehaviour
{
    // Start is called before the first frame update

    private int maxLvl;
    public Text currentLvlText;
    void Start()
    {
        maxLvl = PlayerPrefs.GetInt("LevelReached");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void prevClick()
    {
        if(currentLvlText.text != "1")
        {
            currentLvlText.text =  (int.Parse(currentLvlText.text) - 1).ToString();
        }

    }
    public void nextClick()
    {
        if (int.Parse(currentLvlText.text) < maxLvl)
        {
            currentLvlText.text = (int.Parse(currentLvlText.text) + 1).ToString();
        }

    }
    public void goClick()
    {
        SceneManager.LoadScene(int.Parse(currentLvlText.text));
    }
}
