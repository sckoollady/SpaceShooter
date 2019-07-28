﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    private int score;
    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    void Update()
    {
        if(restart)
        { if(Input.GetKeyDown(KeyCode.R))
         {
            SceneManager.LoadScene("Main");
         }
        }
        if (Input.GetKey("escape"))
      {
         Application.Quit(); 
      }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

     while(true)
     {
        for(int i = 0; i< hazardCount; i++)
        {
        GameObject hazard = hazards[Random.Range(0, hazards.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(hazard, spawnPosition, spawnRotation);
        yield return new WaitForSeconds(spawnWait);
        }
        yield return new WaitForSeconds(waveWait);

        if(gameOver)
        {
            restartText.text = "'R' for Restart";
            restart = true;
            break;
        }
     }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
        if(score >= 100)
        {
            winText.text = "You Win! Game Created By Selena.";
            gameOver = true;
            restart = true;
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
