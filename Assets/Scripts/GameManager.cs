using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject livesHolder; //to hold Live Panel
    public GameObject gameOverPanel; //Game Over Panel

    int score = 0;
    int lives = 3;

    bool gameOver = false;
    public TMP_Text scoreText;
    public TMP_Text finalScoreText; // Displays the final score at Game Over
    public TMP_Text highScoreText; // Displays the high score at Game Over

    private void Awake (){
        instance = this; 
    }

     void Start()
    {
        // Load the high score when the game starts
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            highScoreText.text = "High Score: 0";
        }
    }

    public void IncrementScore(){

        if(!gameOver){ 
        score++;
        scoreText.text = score.ToString(); //convert score to text
        //print(score);
        }
    }

    public void DecreaseLife(){
        if(lives > 0){
            lives--;
            print(lives);

            livesHolder.transform.GetChild(lives).gameObject.SetActive(false); //everytime we are decreasing a life, 1 heart from UI gets deactivated
        }

        if(lives <= 0){
            gameOver = true;
            GameOver();
        }
    }

    public void GameOver(){ //after GAME OVER

        AlienSpawner.instance.StopSpawnAlien(); //aliens stop spawning

        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false; // player cannot move

        gameOverPanel.SetActive(true);

        finalScoreText.text = "Score: " + score.ToString();

        int highScore = PlayerPrefs.GetInt("HighScore", 0); // Get the saved high score

        if (score > highScore) // Check if the player got a new high score
        {
            PlayerPrefs.SetInt("HighScore", score); // Save the new high score
            highScoreText.text = "New High Score: " + score.ToString();
        }
        else
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }

        PlayerPrefs.Save();

        print("GameOver()");
    }

    public void Restart(){
        SceneManager.LoadScene("AlienCatch");
    }

    public void BacktoMenu(){
        SceneManager.LoadScene("Menu");
    }
}
