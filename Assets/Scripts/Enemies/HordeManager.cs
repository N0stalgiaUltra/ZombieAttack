using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script usado para controlar as hordas de inimigos
/// </summary>
public class HordeManager : MonoBehaviour
{

    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private int hordeNumber = 3;
    [SerializeField] private int initialEnemiesCount = 10;
    [SerializeField] private int fixEnemyIncrease = 5;
   
    public int actualRound;
    [SerializeField] private int killCount;
    public int totalEnemiesCount;


    private void Awake()
    {
        totalEnemiesCount = initialEnemiesCount + (hordeNumber * fixEnemyIncrease);
        actualRound = 1;
    }
    private void Update()
    {
        if (killCount >= EnemiesPerRound(actualRound-1))
            EndRound();

    }
    /// <summary>
    /// Calcula o numero de inimigo por round
    /// </summary>
    /// <param name="i">numero do round</param>
    /// <returns>numero de inimigos por round</returns>
    public int EnemiesPerRound(int i) 
    {
        return initialEnemiesCount + (i * fixEnemyIncrease);
    }
    /// <summary>
    /// Usado para saber quando o round terminou
    /// </summary>
    public void EndRound()
    {
        actualRound++;
        if (actualRound > hordeNumber)
            EndLevel();
        else
            StartCoroutine(WaitToRestart());
    }
    /// <summary>
    /// Tempo de espera entre um round terminar e outro começar
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitToRestart()
    {
        yield return new WaitForSecondsRealtime(3f);
        StartRound();
    }
    /// <summary>
    /// Metodo usado para Iniciar um round
    /// </summary>
    public void StartRound()
    {
        killCount = 0;
        enemySpawner.ActivateEnemies(EnemiesPerRound(actualRound-1));
    }
    /// <summary>
    /// Metodo usado para determinar o fim do jogo, isto é, quando todos os rounds(Hordas) foram completados
    /// </summary>
    public void EndLevel()
    {
        GameManager.instance.GameOver(true);
    }
    public int KillCount { get => killCount; set => killCount = value; }
    public int RoundCount { get => hordeNumber; }

}

