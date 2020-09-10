using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Canvas firstTimeCanvas;
    public Canvas mainMenu;
    public Canvas playCanvas;
    public Canvas aboutCanvas;
    private int firstTime;
    private float sound;


    // Start is called before the first frame update
    void Start()
    {
        firstTime = PlayerPrefs.GetInt("FirstTime");
        if (firstTime == 0) PlayerPrefs.SetFloat("Sound", 1f);
        sound = PlayerPrefs.GetFloat("Sound");

        if (firstTime == 1)
        {
            firstTimeCanvas.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
        } 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playClick()
    {
        playCanvas.gameObject.SetActive(true);
    }
    public void aboutClick()
    {

        aboutCanvas.gameObject.SetActive(true);
    }
    public void backClick()
    {
        aboutCanvas.gameObject.SetActive(false);

    }

    public void firstTimeClick()
    {
        PlayerPrefs.SetInt("FirstTime", 1);
        firstTimeCanvas.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);

    }

    public void xClick()
    {
        Application.Quit();
    }

}
