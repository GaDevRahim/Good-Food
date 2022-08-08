using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlScreens : MonoBehaviour
{

    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject scoreScreen;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject greatScreen;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] GameObject gameOverScreen;

    GameManager manager;

    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        titleScreen.SetActive(true);
    }

    internal void OncePlay()
    {
        titleScreen.SetActive(false);
        scoreScreen.SetActive(true);
        manager.StartGame();
    }

    internal void UpdateScore()
    {
        scoreText.text = "Score : " + manager.score;
    }

    internal void UpdateTimer()
    {
        timerText.text = "Timer : " + manager.t;
    }

    internal void ShowFinalScore()
    { 
            greatScreen.gameObject.SetActive(true);
            gameOverScreen.gameObject.SetActive(false);
            scoreScreen.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            finalScoreText.text += "\"" + manager.score + "\"";
    }

    internal void GameOverScreen()
    {
        gameOverScreen.gameObject.SetActive(true);
        greatScreen.gameObject.SetActive(false);
        scoreScreen.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
    }

    internal void GoToHomeScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
