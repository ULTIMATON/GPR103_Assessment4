using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script must be used as the core Player script for managing the player character in the game.
/// </summary>
public class Player : MonoBehaviour
{
    public string playerName = ""; //The players name for the purpose of storing the high score
   
    public int playerTotalLives; //Players total possible lives.
    public int playerLivesRemaining; //PLayers actual lives remaining.
   
    public bool playerIsAlive = true; //Is the player currently alive?
    public bool playerCanMove = false; //Can the player currently move?

    public AudioSource myAudioSource;
    public AudioClip leapVerticalSound;
    public AudioClip leapHorizontalSound;
    public AudioClip deathSound;

    public GameObject dyingEffectPrefab;

    public bool onLog = false;
    public bool inWater = false;


    public GameManager myGameManager; //A reference to the GameManager in the scene.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsAlive != true)
        {
            myGameManager.uiGameOverScreen.SetActive(true);
        }
        if (playerIsAlive && playerCanMove )
        {
            if (Input.GetKeyDown(KeyCode.W) && transform.position.y < myGameManager.levelConstraintTop)
            {
                transform.position = transform.position + new Vector3(0, 1, 0);
                myAudioSource.clip = leapVerticalSound;
                myAudioSource.Play();
                
                myGameManager.UpdatedScore(10);
            }
            else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > myGameManager.levelConstraintBottom)
            {
                transform.position = transform.position + new Vector3(0, -1, 0);
                myAudioSource.clip = leapVerticalSound;
                myAudioSource.Play();
                
            }
            else if (Input.GetKeyDown(KeyCode.A) && transform.position.x > myGameManager.levelConstraintLeft)
            {
                transform.position = transform.position + new Vector3(-1, 0, 0);
                myAudioSource.clip = leapHorizontalSound;
                myAudioSource.Play();
            }
            else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < myGameManager.levelConstraintRight)
            {
                transform.position = transform.position + new Vector3(1, 0, 0);
                myAudioSource.clip = leapHorizontalSound;
                myAudioSource.Play();
            }

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(playerIsAlive == true)
        {
            if (collision.transform.GetComponent<Vehicle>() !=null)
            {
                print("hit");
                playerCanMove = false;
                playerIsAlive = false;
                myAudioSource.clip = deathSound;
                myAudioSource.Play();
                Instantiate(dyingEffectPrefab, transform.position, Quaternion.identity);
                GetComponent<SpriteRenderer>().enabled = false;
            }
            if (playerIsAlive != true)
            {
                myGameManager.GameOver(false);
            }
            else if (collision.transform.GetComponent<Vehicle2>() != null)
            {
                transform.SetParent(collision.transform);
                onLog = true;
            }
            else if (collision.transform.tag == "EndZone")
            {
                myGameManager.UpdatedScore(150);
                myGameManager.GameOver(true);
                print("You Won!");
                playerCanMove = false;
            }
            else if (collision.transform.tag == "Water")
            {
                inWater = true;
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (playerIsAlive == true)
        {
            if (collision.transform.GetComponent<Vehicle2>() != null)
            {
                onLog = false;
                transform.SetParent(null);
            }
            else if (collision.transform.tag == "Water")
            {
                inWater = false;
            }

        }
    }

    private void LateUpdate()
    {
        if(playerIsAlive)
        {
            if (inWater == true && onLog == false)
            {
                playerIsAlive = false;
                playerCanMove = false;
                myAudioSource.clip = deathSound;
                myAudioSource.Play();

            }
        }
        if (playerIsAlive == false)
        {
            myGameManager.GameOver(false);
        }
    }



}
