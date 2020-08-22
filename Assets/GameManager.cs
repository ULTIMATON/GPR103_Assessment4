using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// This script is to be attached to a GameObject called GameManager in the scene. It is to be used to manager the settings and overarching gameplay loop.
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Scoring")]
    public int currentScore = 0; //The current score in this round.
    public int highScore = 0; //The highest score achieved either in this session or over the lifetime of the game.

    [Header("Playable Area")]
    public float levelConstraintTop; //The maximum positive Y value of the playable space.
    public float levelConstraintBottom; //The maximum negative Y value of the playable space.
    public float levelConstraintLeft; //The maximum negative X value of the playable space.
    public float levelConstraintRight; //The maximum positive X value of the playablle space.

    [Header("Gameplay Loop")]
    public bool isGameRunning; //Is the gameplay part of the game current active?
    public float totalGameTime; //The maximum amount of time or the total time avilable to the player.
    public float gameTimeRemaining; //The current elapsed time

    [Header ("UI Window")]
    public GameObject uiGameOverScreen;
    public TMP_Text uiGameOverMessage;
    public TMP_Text uiCurrentScore;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
            
    }

   
    public void RestartingGame()
    {
        print("Restarting scene");
        SceneManager.LoadScene(0);
    }

    public void GameOver(bool isVictory)
    {
        if (isVictory == true)
        {
            uiGameOverMessage.text = "You Have Won!";
        }
        else
        {
            uiGameOverMessage.text = "You Have Lost!";
        }
             
        uiGameOverScreen.SetActive(true);
    }

    public void UpdatedScore(int amount)
    {
        currentScore += amount;
        uiCurrentScore.text = "Score: " + currentScore.ToString();
    }

}
