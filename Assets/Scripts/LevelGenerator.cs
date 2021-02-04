using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //public Vector2 startingPos=new Vector2(0, -3);
    public GameObject prefab;
    public GameObject prefabGround2;
    public GameObject tubePrefab;
    public GameObject tubeR;
    public GameObject scorePrefab;

    public int blockCounter=0;
    public int tileGenerationHeight = -4;
    public int block = 0;

    public int tubeCounter = 0;
    public int tube = 0;

    public int tubeBetweenDistance = 5;
    public float tubeHeight=3f;
    public int tubesOnLevel=5;

    public float tubeSpacing=8f;
    public float tubeUPLimiter = 3;
    public float tubeDOWNLimiter = -3;


    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        if (blockCounter < 54)//to zmieniłem z 27 na 54
        {
            GenerateMore();
        }
        
    }

    void Generate()
    {
        blockCounter += 60;//to zmienilem z 30 na 60

        for (int i = 0; i < 30; i++)
        {
            Instantiate(prefab, new Vector2(i, tileGenerationHeight), Quaternion.identity);
            Instantiate(prefabGround2, new Vector2(i, tileGenerationHeight-1), Quaternion.identity);
            block = i;
        }
        
    }

    public void GenerateMore()
    {
        blockCounter += 40;//to zmieniłem z 20 na 40
        int i;
        for (i = 0; i < 20; i++)
        {
            Instantiate(prefab, new Vector2(i + block, tileGenerationHeight), Quaternion.identity);
            Instantiate(prefabGround2, new Vector2(i+block, tileGenerationHeight - 1), Quaternion.identity);

            //Tubes Generator v2
            if (i == 0||i==10)
            {
                
                    tubeHeight = Random.Range(-4.3f, -1f);

                    Instantiate(tubePrefab, new Vector2(i + block, (float)tileGenerationHeight  + tubeHeight + 3), Quaternion.identity);
                    Instantiate(tubeR, new Vector2(i + block, (float)tileGenerationHeight  + tubeHeight + tubeSpacing + 3), Quaternion.identity);
                //score
                Instantiate(scorePrefab, new Vector2((float)i + (float)block-1.5f, (float)tileGenerationHeight + tubeHeight + tubeSpacing -1.2f), Quaternion.identity);
                



                //lastTubeHeight = tubeHeight;
            }
        }
        block += i;
    }

}
