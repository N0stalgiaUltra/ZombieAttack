using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// Script responsavel por controlar a HUD do player
/// </summary>
public class HudManager : MonoBehaviour
{
    [SerializeField] private HordeManager hordeManager;
    [SerializeField] private ScoreManager scoreManager;
    
    [Header("TextMesh References")]
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI hordeText;
    [SerializeField] private TextMeshProUGUI enemiesCountText;
    [SerializeField] private TextMeshProUGUI playerScore;


    // Update is called once per frame
    void Update()
    {
        SetUI();
    }
    /// <summary>
    /// Usado para atribuir os valores de atributos aos textos
    /// </summary>
    public void SetUI()
    {
        
        playerName.text = PlayerPrefs.GetString("UserName"); 
        playerScore.text = $"Score: {scoreManager.Score}"; 
        hordeText.text = $"Horde: {hordeManager.actualRound}/{hordeManager.RoundCount}";
        enemiesCountText.text = $"Enemies: {hordeManager.KillCount}/{hordeManager.EnemiesPerRound(hordeManager.actualRound-1)}";
    }
}
