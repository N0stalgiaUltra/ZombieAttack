using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Script usado apra controlar a tela de gameover
/// </summary>
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText, scoreText, highScoreText;
    [SerializeField] private Button retryButton;

    private void Start()
    {
        retryButton.onClick.AddListener(ReloadScene);
    }
    /// <summary>
    /// Usado para atribuir os textos na tela 
    /// </summary>
    /// <param name="value">se o player venceu ou perdeu</param>
    /// <param name="score">score do player</param>
    /// <param name="highscore">highscore do player</param>
    public void SetGameOverScreen(bool value, int score, int highscore)
    {
        gameOverText.text = value ?  "YOU SURVIVED!" : "YOU DIED!";
        scoreText.text = $"Your Score: {score}";
        highScoreText.text =$"Highscore: {highscore}";

    }
    /// <summary>
    /// Recarrega a cena
    /// </summary>
    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(scene.buildIndex);
    }
}
