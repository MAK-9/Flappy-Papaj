using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScore;
    public Text score;
   

    public void UpdateHighScore()
    {
        highScore.text = score.text;
    }
}
