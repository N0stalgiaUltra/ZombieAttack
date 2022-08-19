using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script responsável por controlar o pooling de inimigos
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private HordeManager hordeManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private List<EnemyData> enemiesType = new List<EnemyData>(3);
    [SerializeField] private List<float> spawnChance = new List<float>(3);
    [SerializeField] private List<Transform> spawnPosition = new List<Transform>(3);

    private Queue<GameObject> enemyPool = new Queue<GameObject>();
    void Start()
    {
        int aux = hordeManager.totalEnemiesCount;
        for (int i = 0; i < enemiesType.Count; i++)
            spawnChance.Add(enemiesType[i].spawnPercentage);
        
        FillQueue(aux);
        
    }

    /// <summary>
    /// Script responsável por adicionar os inimigos na fila(Queue)
    /// </summary>
    /// <param name="aux">total de inimigos</param>
    private void FillQueue(int aux)
    {
        for (int i = 0; i < aux; i++)
        {
            GameObject aux2 = Instantiate(enemiesType[GetRandomSpawn()].prefab, spawnPosition[Random.Range(0,3)]);
            aux2.SetActive(false);
            enemyPool.Enqueue(aux2);
        }
    }

    /// <summary>
    /// Usado para adicionar um inimigo baseado na sua chance (spawn rate) de spawn
    /// </summary>
    /// <returns> um indice baseado na chance de spawn do inimigo </returns>
    private int GetRandomSpawn()
    {
        float random = Random.Range(0f,1f);
        float aux = 0;
        float total = 0;

        for (int i = 0; i < spawnChance.Count; i++)
            total += spawnChance[i];

        for (int i = 0; i < enemiesType.Count; i++)
        {
            if (spawnChance[i] / total + aux >= random)
                return i;
            else 
                aux += spawnChance[i] / total;
        }

        return 0;
    }
    /// <summary>
    /// Metodo usado para ativar os inimigos na cena
    /// </summary>
    /// <param name="aux">indice do inimigo na fila</param>
    public void ActivateEnemies(int aux)
    {
        if(enemyPool.Count == 0)
        {
            FillQueue(aux);
        }
        else
        {
            StartCoroutine(DequeueEnemies(aux));
            
        }
    
    }
    /// <summary>
    /// Usado para ativar os inimigos com o tempo, para que eles não apareçam todos juntos no mesmo instante
    /// </summary>
    /// <param name="aux">indice de inimigos a ser spawnados</param>
    /// <returns>espera 0.5s e instancia um inimigo</returns>
    IEnumerator DequeueEnemies(int aux)
    {
        for (int i = 0; i < aux; i++)
        {
            enemyPool.Dequeue().SetActive(true);
            yield return new WaitForSeconds(.5f);
        }
    }
    /// <summary>
    /// Usado para desativar o inimigo e retorná-lo ao pool
    /// </summary>
    /// <param name="enemy">objeto do inimigo</param>
    /// <param name="data">EnemyData do inimigo</param>
    public void DeactivateEnemy(GameObject enemy, EnemyData data)
    {
        scoreManager.SetScore(data.score);
        hordeManager.KillCount++;
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }

}
