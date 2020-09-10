using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public Text timeLeftText;
    public Text bananaCount;
    public Button GameOverButton;
    public Button stageFinishedButton;
    private int totalBananas;
    private int collectedBananas = 0;
    public AudioSource collectedSound;
    public int[] timesforStages;
    float timeleft = 40f;
    public Canvas menu;

    private int deathCounter;


    public static GameManager singleton;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("3666959");
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        timeleft -= Time.deltaTime;
        timeLeftText.text = (int)timeleft + " s";
        if (timeleft <= 0) showGameOver();

        if (GameOverButton.IsActive())
        {
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)){
                restartScene();
            }

        }
        if (stageFinishedButton.IsActive())
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                nextStage();
            }

        }
        
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        totalBananas = GameObject.FindGameObjectsWithTag("Banana").Length;
        collectedBananas = 0;
        bananaCount.text = collectedBananas + " / " + totalBananas;
        timeleft = timesforStages[SceneManager.GetActiveScene().buildIndex-1];


    }

    public void playCollectSound()
    {
        collectedSound.Play();

    }
    public void updateScore()
    {
        playCollectSound();
        collectedBananas++;
        bananaCount.text = collectedBananas + " / " + totalBananas;

    }

    public void showGameOver()
    {
        deathCounter = PlayerPrefs.GetInt("DeathCounter");
        deathCounter++;

        if (deathCounter == 3)
        {
            Advertisement.Show();
            Debug.Log("AD se prikazuje");
            deathCounter = 0;

        }
        PlayerPrefs.SetInt("DeathCounter", deathCounter);
        GameOverButton.gameObject.SetActive(true);

    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void showMenu()
    {
        Time.timeScale = 0f;
        menu.gameObject.SetActive(true);
    }
    public void hideMenu()
    {
        Time.timeScale = 1f;
        menu.gameObject.SetActive(false);
    }

    public void finishCheck()
    {
        if (collectedBananas == totalBananas)
        {
            stageFinishedButton.gameObject.SetActive(true);
        }
    }
    public void nextStage()
    {
        if (SceneManager.GetActiveScene().buildIndex <= SceneManager.sceneCount+1){
            PlayerPrefs.SetInt("LevelReached", SceneManager.GetActiveScene().buildIndex+1);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else SceneManager.LoadScene(0);
    }

    public void mainMenuClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
