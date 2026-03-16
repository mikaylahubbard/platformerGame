
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Static reference to the single instances
    public static GameManager Instance { get; private set; }


    public event Action<int> onScoreChanged;
    public event Action<int> onHealthChanged;
    public event Action onGameOver;
    public int score = 0;
    public int health = 100;



    void Awake()
    {
        // If an instance already exists and it's not this one, destroy this
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set this as the instance
        Instance = this;

        // Persist this GameObject across all scenes
        DontDestroyOnLoad(gameObject);
    }

    public void AddPoints(int points)
    {
        if (points >= 0)
        {
            score += points;
            onScoreChanged?.Invoke(score);
        }

        if (score >= 120)
        {
            onGameOver?.Invoke();
        }
    }

    public void takeDamage(int damage)
    {
        if (damage >= 0)
        {
            health -= damage;
            onHealthChanged?.Invoke(health);
        }

        if (health <= 0)
        {
            onGameOver?.Invoke();
        }
    }



}
