
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Content;
public class PlayerController : MonoBehaviour
{

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public float moveSpeed = 5f;
    public float jumpForce = 20f;
    private bool isGrounded = false;
    // private int score = 0;
    // private int health = 100;
    private Rigidbody2D rb;

    void Start()
    {
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
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.jumpSound);
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
            // score += 10;
            GameManager.Instance.AddPoints(10);
            // Destroy(other.gameObject);
            CoinPoolManager.Instance.ReturnCoin(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        GameManager.Instance.takeDamage(damage);
        // Debug.Log("Health: " + health);

    }

}