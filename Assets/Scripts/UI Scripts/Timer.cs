using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 60f;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;

    private bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameOver) return;

        // ✅ WIN CHECK (FIXED)
        if (TrashCounter.Instance != null &&
            TrashCounter.Instance.GetRemainingItems() <= 0)
        {
            WinGame();
            return;
        }

        // ⏱ TIMER
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            timeRemaining = 0;
            GameOver();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        if (timerText != null)
        {
            timerText.text = "TIME: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    void GameOver()
    {
        isGameOver = true;

        Debug.Log("GAME OVER");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        ShowCursorAndPause();
    }

    void WinGame()
    {
        isGameOver = true;

        Debug.Log("YOU WIN");

        if (winPanel != null)
            winPanel.SetActive(true);

        ShowCursorAndPause();
    }

    void ShowCursorAndPause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}