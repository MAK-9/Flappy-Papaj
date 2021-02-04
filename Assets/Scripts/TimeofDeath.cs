using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeofDeath : MonoBehaviour
{
    public Text time;
    GameObject jaskier;
    Audio audioScript;

    GameObject highScore;
    HighScore highScoreScript;
    GameObject score;
    Animator flicker;

    void Start()
    {
        jaskier = GameObject.Find("SoundMaker");

        audioScript = jaskier.GetComponent<Audio>();

        highScore = GameObject.Find("HighScore");
        highScoreScript = highScore.GetComponent<HighScore>();

        score = GameObject.Find("Score");

        flicker = GetComponent<Animator>();
    }

    public void itsAboutTime()
    {

        StartCoroutine(Waiter());

    }

    public IEnumerator Waiter()
    {
        //ustaw highScore na score
        highScoreScript.UpdateHighScore();

        //wyjeb zwykły score z ekranu
        score.SetActive(false);

        time.text = "21:35";
        yield return new WaitForSecondsRealtime(1);

        time.text = "21:36";
        yield return new WaitForSecondsRealtime(1);

        audioScript.grajDeathBell();
        flicker.SetBool("doFlickering", false);

        time.text = "21:37";
        
    }
}
