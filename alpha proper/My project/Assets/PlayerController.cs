using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 2f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Vector3 startPosition;  // Store the starting position of the player
    public float fallThreshold = -10f;  // Y position threshold for respawning

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;  // Set the starting position when the game begins
    }

    void Update()
    {
        // Horizontal Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log("Horizontal Input: " + horizontalInput); // Debug log to check input
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            Debug.Log("Jumped"); // Debug log for jumping action
        }

        // Check if player has fallen below the threshold
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if landed on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Landed on Ground"); // Debug log for ground collision
        }
    }

    // Method to respawn the player at the starting position
    private void Respawn()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;  // Reset the player's velocity to prevent carrying momentum
        Debug.Log("Respawned at Start Position"); // Debug log for respawn action
    }
}
