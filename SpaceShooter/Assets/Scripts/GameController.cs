using System.Collections;
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
    public Text hardText;
    public bool winGame;
    public AudioClip winMusic;
    public AudioClip loseMusic;
    public AudioSource audioSource;
    private int score;
    private bool gameOver;
    private bool restart;
    public bool hard;
    private int WaveCount = 0;
    private int HazardCountPlus = 2;



    void Start()
    {
        gameOver = false;
        restart = false;
        hard = false;
        gameOverText.text = "";
        restartText.text = "";
        winText.text = "";
        hardText.text = "";
        score = 0;
        winGame = false;
        UpdateScore();
        if (hard == false)
        {
        StartCoroutine (SpawnWaves());
        }
      
    }

    void Update()
    {
        if(restart)
        { if(Input.GetKeyDown(KeyCode.Space))
         {
            SceneManager.LoadScene("Main");
         }
        }
        if (Input.GetKey("escape"))
      {
         Application.Quit(); 
      }
       if(Input.GetKeyDown(KeyCode.H))
      {
          hazardCount = hazardCount + 45;
          hard = true;
          SceneManager.LoadScene("Main");
          if(hard = true)
          {
          StartCoroutine(SpawnHard());
          }
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
            restartText.text = "Press 'Space' to restart";
            restart = true;
            break;
        }
     }
    }

    IEnumerator SpawnHard()
    {
        yield return new WaitForSeconds(startWait);

     while(true)
     {
         hazardCount += (WaveCount * HazardCountPlus);
        for(int i = 0; i< hazardCount; i++)
        {
        GameObject hazard = hazards[Random.Range(0, hazards.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(hazard, spawnPosition, spawnRotation);
        yield return new WaitForSeconds(spawnWait);
        }
        yield return new WaitForSeconds(waveWait);
        WaveCount++;

        if(gameOver)
        {
            restartText.text = "Press 'Space' to restart";
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
        ScoreText.text = "Points: " + score;
        if(score >= 100)
        {
            winText.text = "You Win! Game Created By Selena.";
            gameOver = true;
            restart = true;
            winGame = true;
            audioSource.clip = winMusic;
            audioSource.Play();
            hardText.text = "Press 'H' for Hard Mode";
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        audioSource.clip = loseMusic;
        audioSource.Play();
    }
}

