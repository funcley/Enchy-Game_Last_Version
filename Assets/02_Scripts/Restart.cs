using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Restart : MonoBehaviour

{
    /*public GameObject HighScoreAlert;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        int score = PlayerPrefs.GetInt("score");
        int highScore;
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        else 
        {
            highScore = 0; 
        }
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = score.ToString();
            HighScoreAlert.SetActive(true);
        }
        else
        {
            HighScoreAlert.SetActive(false);
            highScoreText.text = highScore.ToString();
        }
        scoreText.text = score.ToString();
    }*/

    public string ScenetoPlay; 

   public void RestartGame()
   {
       Scene scene = SceneManager.GetActiveScene();
       SceneManager.LoadScene(scene.name);

   }
   public void StartGame()
   {
      
       SceneManager.LoadScene(ScenetoPlay);

   }
   public void QuitGame()
   {
       Application.Quit();
       //UnityEditor.EditorApplication.isPlaying = false;
   }

    
}
