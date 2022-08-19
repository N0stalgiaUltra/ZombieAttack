using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script utilitario para encontrar os players na cena
/// </summary>
public class PlayerFinder : MonoBehaviour
{
    [SerializeField] private List<GameObject> playersList = new List<GameObject>();

    public static PlayerFinder instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;

        playersList = GameObject.FindGameObjectsWithTag("Player").ToList();
    }
    /// <summary>
    /// Caso um player seja adicionado na cena, ele será adicionado na lista
    /// </summary>
    /// <param name="player">player adicionado na cena</param>
    public void AddPlayer(GameObject player) => playersList.Add(player);
    
    /// <summary>
    /// Metodo usado pra saber qual o player mais proximo do inimigo
    /// </summary>
    /// <param name="currEnemy">inimigo </param>
    /// <returns>player mais proximo do inimigo</returns>
    public GameObject ReturnNearestPlayer(Transform currEnemy)
    {
        float currDist = 0;
        float minDist = 0;
        GameObject aux = null;

        for (int i = 0; i < playersList.Count; i++)
        {
            currDist = Vector3.Distance(currEnemy.position, playersList[i].transform.position);

            if (minDist == 0)
                minDist = currDist;

            if (currDist <= minDist)
            {
                minDist = currDist;
                aux = playersList[i];
            }

        }

        return aux;
    }
}
