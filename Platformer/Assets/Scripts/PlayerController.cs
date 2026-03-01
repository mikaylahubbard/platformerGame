
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public float moveSpeed = 5f;
    public float jumpForce = 20f;
    private bool isGrounded = false;
    private int score = 0;
    private int health = 100;
    private Rigidbody2D rb;

    void Start()
    {
        UpdateUI();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // left/right movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Coin"))
        {
            score += 10;
            UpdateUI();
            Debug.Log("Score " + score);
            Destroy(other.gameObject);

            if (score >= 120)
            {
                PlayerPrefs.SetInt("FinalScore", score);
                SceneManager.LoadScene(2);
            }
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        UpdateUI();
        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            // Game over
            Debug.Log("Player died!");
            PlayerPrefs.SetInt("FinalScore", score);
            SceneManager.LoadScene(2);
        }
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
    }
}