using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ช่องแสดงคะแนน
    private int displayedScore = 0;
    public float score = 0f; 
    public float pipeSpeed = 2f;
    public GameObject gameOverPanel;
    public bool isGameOver = false;
    public GameObject startPanel;
    public bool isGameStarted = false;
    public static GameManager instance;

    public float elapsedTime = 0f;

    void Start()
    {
        gameOverPanel.SetActive(false);

        if (startPanel != null)
        {
            startPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    void Update()
    {
        if (isGameOver || !isGameStarted) return;

        score += Time.deltaTime * 500f;

        elapsedTime += Time.deltaTime;

        pipeSpeed = 2f + (elapsedTime * 0.05f);
        pipeSpeed = Mathf.Min(pipeSpeed, 200f);

        int realScore = Mathf.FloorToInt(score);
        if (displayedScore < realScore)
        {
            displayedScore++;
            UpdateScoreText();
        }
    }
    void UpdateScoreText()
    {
        scoreText.text = displayedScore.ToString("D8"); 
    }

    public void StartGame()
    {
        isGameStarted = true;
        if (startPanel != null) startPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
