using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;
    [Header("Game Over Elements")]
    public GameObject gameOverPanel;

    [Header("Sound Elements")]
    public AudioClip[] sliceSounds;
    public AudioClip[] bombSounds;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GetHighScore();
    }

    private void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best: "+highScore.ToString();
    }

    public void InCreaseScore(int addedPoints)
    {
        score += addedPoints;
        scoreText.text = score.ToString();

        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore",score);
            highScoreText.text = "Best: " + score.ToString();
        }
    }

    public void OnBombHit()
    {
        Debug.Log("Bomb hit");
        gameOverPanel.SetActive(true);
        //Stop any movement in the game
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayRandomSliceSound()
    {
        AudioClip randomSound = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }


    public void PlayBombSound()
    {
        AudioClip randomSound = bombSounds[Random.Range(0, bombSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }




}
