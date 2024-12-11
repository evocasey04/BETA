using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the UI text displaying the score
    public float scoreMultiplier = 10f; // Multiplier for score (e.g., points per second)

    private float score; // Tracks the current score
    private bool isGameActive = true; // Whether the game is active

    public float GetScore()
    {
        return score; // Return the current score
    }


    void Update()
    {
        if (isGameActive)
        {
            // Increase score based on time and multiplier
            score += Time.deltaTime * scoreMultiplier;

            // Update the score text
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void StopScoring()
    {
        isGameActive = false; // Stop scoring when the game ends
    }
     
    public void ResetScore()
    {
        score = 0; // Reset the score if the game restarts
        scoreText.text = "Score: 0";
    }
}
