using UnityEngine;
using TMPro;

public class PlayerCollisionHandler : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText; // Reference to the UI element for the final score
    public GameObject gameOverScreen; // Reference to the Game Over UI panel
    public ScoreManager scoreManager; // Reference to the ScoreManager script
    public AudioSource deathSoundSource; // Reference to the AudioSource for the death sound

    void Start()
    {
        // Ensure the Game Over screen is initially inactive
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collided with a spike or falling item
        if (collision.CompareTag("Spike") || collision.CompareTag("FallingItem"))
        {
            PlayDeathSound();
            StopGame();
        }
    }

    private void PlayDeathSound()
    {
        if (deathSoundSource != null && deathSoundSource.clip != null)
        {
            deathSoundSource.Play(); // Play the death sound
        }
    }

    private void StopGame()
    {
        // Pause the game after a slight delay to allow the death sound to play
        StartCoroutine(StopGameWithDelay());
    }

    private System.Collections.IEnumerator StopGameWithDelay()
    {
        // Allow the death sound to play completely before pausing the game
        if (deathSoundSource != null && deathSoundSource.clip != null)
        {
            yield return new WaitForSecondsRealtime(deathSoundSource.clip.length);
        }

        // Pause the game
        Time.timeScale = 0;

        // Show the Game Over screen
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        // Display the final score
        if (finalScoreText != null && scoreManager != null)
        {
            finalScoreText.text = "Final Score: " + Mathf.FloorToInt(scoreManager.GetScore());
        }

        Debug.Log("Game Over! Final Score: " + scoreManager.GetScore());
    }
}
