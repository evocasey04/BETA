using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject titleScreen; // Reference to the Title Screen UI panel

    void Start()
    {
        // Start the game paused
        Time.timeScale = 0;

        // Ensure the title screen is active
        if (titleScreen != null)
        {
            titleScreen.SetActive(true);
        }

        Debug.Log("Game is paused. Waiting for Start...");
    }

    public void StartGame()
    {
        // Disable the title screen
        if (titleScreen != null)
        {
            titleScreen.SetActive(false);
        }

        // Unpause the game
        Time.timeScale = 1;

        Debug.Log("Game Started!");
    }
}
