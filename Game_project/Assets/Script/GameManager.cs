using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int finalScore = 0;  // �߰�: ������ ���� ��Ͽ�

    public int score = 0;
    public int lives = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void LoseLife()
    {
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        finalScore = score;  // ���⼭ ���� ���
        SceneManager.LoadScene("GameOverScene");
    }
}
