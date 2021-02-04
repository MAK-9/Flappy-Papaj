using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollider : MonoBehaviour
{
    GameObject score;
    Score scoreScript;

    void Start()
    {
        score = GameObject.Find("Score");
        scoreScript = score.GetComponent<Score>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            scoreScript.AddScore(1);
            Destroy(gameObject);
        }
       
    }
}
