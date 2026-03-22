using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text scoreText;

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

}