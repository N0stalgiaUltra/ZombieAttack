using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script usado para controlar a mira automatica
/// </summary>
public class Autoaim : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesList = new List<GameObject>();
    [SerializeField] private Transform player;

    [SerializeField] private int count;
    private string enemyTag;


    void Start()
    {
        InputManager.playerAimed += AutoAim;
        count = 0;
    }


    /// <summary>
    /// Adiciona um inimigo para a lista de objetos na mira automatica
    /// </summary>
    /// <param name="aux">objeto a ser adicionado</param>
    private void AddToList(GameObject aux)
    {
        if (enemyTag.Equals("InimigoPadrao") ||
            enemyTag.Equals("InimigoForte") || 
            enemyTag.Equals("InimigoRapido"))
        {
            enemiesList.Add(aux);
            aux = null;
        }
        else
            return;
        
    }
    /// <summary>
    /// Remove um inimigo da lista
    /// </summary>
    /// <param name="aux">objeto a ser removido </param>
    public void RemoveFromList(GameObject aux)
    {
        if(enemiesList.Contains(aux))            
        {
            enemiesList.Remove(aux);
        }
    }
    /// <summary>
    /// Caso um inimigo esteja na lista, o player olha pra ele (mira automatica)
    /// </summary>
    private void AutoAim()
    {
        if (enemiesList.Count != 0)
        {
            if (count >= enemiesList.Count)
                count = 0;

            player.transform.LookAt(enemiesList[count].transform);
            count++;
        }
        else return;        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.activeSelf)
        {
            enemyTag = other.tag;
            AddToList(other.gameObject);
            EnemyHealth.enemyDead += EnemyKilled; 
        }
    }



    private void OnTriggerExit(Collider other)
    {
        enemyTag = other.tag;
        RemoveFromList(other.gameObject);
        EnemyHealth.enemyDead -= EnemyKilled;
    }
    /// <summary>
    /// Evento chamado quando o inimigo é morto
    /// </summary>
    /// <param name="obj">inimigo a ser removido da lista</param>
    private void EnemyKilled(GameObject obj) => RemoveFromList(obj);

    private void OnDisable()
    {
        InputManager.playerAimed -= AutoAim;

    }
}
