using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int tutorialFinished;

    public Button jumpButton;
    void Start()
    {
        tutorialFinished = PlayerPrefs.GetInt("TutorialFinished");
        if (tutorialFinished == 1) Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (jumpButton.image.color.a == 0f)
         jumpButton.image.color = new Color(1, 1, 1, 1f);
        else jumpButton.image.color = new Color(1, 1, 1, 0f);
        PlayerPrefs.SetInt("TutorialFinished",1);
        Destroy(this.gameObject);



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerPrefs.SetInt("TutorialFinished", 1);
        Destroy(this.gameObject);

    }
}
