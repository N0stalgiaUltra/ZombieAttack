using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script usado para controlar o colisor do player
/// </summary>
public class PlayerCollider : PlayerHealth, ICollider
{
    [Serializable]
    public struct Enemy
    {
        public string nameEnemy;
        public EnemyData data;
    }
    [SerializeField] private Enemy[] enemyData = new Enemy[3];

    private string enemyTag;

    /// <summary>
    /// Chamado quando o player encostar em um inimigo, implementado da interface ICollider
    /// </summary>
    public void GetHit()
    {
        foreach(Enemy e in enemyData)
        {
            if (enemyTag.Equals(e.nameEnemy))
            {
                Damage(e.data.damage / 10);
                Debug.Log($"Dano: {e.data.damage}, Inimigo: {e.nameEnemy}");
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        enemyTag = collision.gameObject.tag;
        GetHit();
    }

}
