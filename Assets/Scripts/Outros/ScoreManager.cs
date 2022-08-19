using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script usado para controlar a pontuação do jogo
/// </summary>
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int highScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    /// <summary>
    /// Usado para incrementar a pontuação
    /// </summary>
    /// <param name="scoreEnemy">valor de pontuação ao matar um inimigo</param>
    public void SetScore(int scoreEnemy) 
    {
        this.score += scoreEnemy;
    }
    /// <summary>
    /// Usado para salvar o score e highscore
    /// </summary>
    public void SaveScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        PlayerPrefs.Save();
    }

    public int Score { get => score; }
    public int Highscore { get => highScore; }
}
