using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{

    public TMP_Text scoreText;
    public TMP_InputField playerNameInput;


    void Start()
    {
        int finalScore = GameManager.Instance.score;
        scoreText.text = "Final Score: " + finalScore;
    }
    public void StartGame()
    {
        //Loads the GameScene scene
        CoinPoolManager.Instance.ResetAllCoins();
        GameManager.Instance.score = 0;
        GameManager.Instance.health = 100;
        SceneManager.LoadScene("GameScene");

    }

    public void OnSubmitScore()
    {
        string playerName = playerNameInput.text;

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Anonymous";
        }

        int finalScore = GameManager.Instance.score;
        float completionTime = Time.timeSinceLevelLoad;

        DatabaseManager.Instance.SaveHighScore(playerName, finalScore, completionTime);

        SceneManager.LoadScene("HighScores");
    }

}