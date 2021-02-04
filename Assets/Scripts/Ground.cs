using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    public GameObject level;
    public LevelGenerator levelScript;

    void Start()
    {
        level = GameObject.Find("Level");
        levelScript = level.GetComponent<LevelGenerator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Eraser")
        {
            levelScript.blockCounter--;

            Destroy(gameObject);
        }
    }
}
