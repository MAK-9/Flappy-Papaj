using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;


    GameObject jaskier;
    Audio audioScript;

    GameObject player;
    PlayerConrtoller2D playerScript;

    void Start()
    {
        jaskier = GameObject.Find("SoundMaker");
        audioScript = jaskier.GetComponent<Audio>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerConrtoller2D>();
    }
    
    public void AddScore(int val)
    {
        score += val;
        scoreText.text = score.ToString();



        if (score % 5 == 0)
        {
            //przyspiesz papaja
            playerScript.IncreaseSpeed(0.4f,.1f,1f);

            //graj jeszczejak
            //Debug.Log("gram jeszcze jak!");
            audioScript.grajRandom();
        }
    }
}
