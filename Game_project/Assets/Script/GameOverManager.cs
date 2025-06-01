using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverSceneManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        finalScoreText.text = "Score: " + GameManager.finalScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}

