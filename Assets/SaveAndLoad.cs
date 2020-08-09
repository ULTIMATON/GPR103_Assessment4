using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public int playerHighScore = 0;
    public int playerCurrentScore = 0;

    public string playersName;

    public float gameTimer;
    public bool isGameOver = false;

    List<string> highScore = new List<string>(5);

    // Start is called before the first frame update
    void Start()
    {
        playerHighScore = PlayerPrefs.GetInt("HighScore");
        playersName = PlayerPrefs.GetString("PlayerName");

        print("Current High Score: " + playerHighScore);
        print("Players name: " + playersName);
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        if (gameTimer <= 0 && isGameOver != true)
        {
            isGameOver = true;

            if (playerCurrentScore > playerHighScore)
            {
                playerHighScore = playerCurrentScore;
                PlayerPrefs.SetInt("HighScore", playerHighScore);
            }
        }
    }
}
