using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerConrtoller2D : MonoBehaviour
{

    GameObject Jaskier;
    Audio audioScript;

    GameObject deathScreen;
    GameObject timeText;
    TimeofDeath timeScript;

    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    private bool canJump = true;
    public float upVelocity = 4f;
    public float deathHeight = -3f;
    public float horizontalVelocity = 2f;

    private float verVelocity;

    bool postpone = false;
    public float jumpCooldown = 0.4f;
    public float rotSpeed = 4f;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Jaskier = GameObject.Find("SoundMaker");
        audioScript = Jaskier.GetComponent<Audio>();

        deathScreen = GameObject.Find("DeathScreen");
        timeText = GameObject.Find("Time");
        timeScript = timeText.GetComponent<TimeofDeath>();

        deathScreen.SetActive(false);
    }

    void Update()
    {
        verVelocity = rb2d.velocity.y;
        rb2d.velocity = new Vector2(horizontalVelocity, verVelocity);


        if(rb2d.transform.position.y<8)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                canJump = true;
                
            }
        }
        
        if (Time.timeScale == 0)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
            }
        }
    }
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) && canJump == true && postpone == false)
        {
            rb2d.velocity = new Vector2(0, upVelocity);

            audioScript.grajJump();

           

            canJump = false;
            StartCoroutine(PostponeJump());
        }


        if (horizontalVelocity > 3)
        {
            rb2d.transform.Rotate(Vector3.back * Time.deltaTime*rotSpeed);
        }

        

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Tubes"|| collision.gameObject.tag == "Ground")
        {
            Die();
        }
        
    }
    public void Die()
    {
        //Time.timeScale = 0;
        Debug.Log("2137");
        audioScript.grajDeath();
        Time.timeScale = 0;
        deathScreen.SetActive(true);

        //aktywuj odliczanie zegara
        timeScript.itsAboutTime();

    }

    //BETA FUNCTIONS

    //Speed Increaser
    public void IncreaseSpeed(float value,float value1,float rot)
    {
        horizontalVelocity += value;
        verVelocity += value1;
        rotSpeed += rot;
    }


    //Jump adjustments
    IEnumerator PostponeJump()
    {
        postpone = true;
        yield return new WaitForSeconds(jumpCooldown);
        postpone = false;
    }
    
}
