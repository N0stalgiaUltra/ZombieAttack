using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script usado para controlar a colisão do inimigo
/// </summary>
public class EnemyCollider : EnemyHealth, ICollider
{

    private string colliderTag;
    [SerializeField] private int damage;


    /// <summary>
    /// Metodo implementado da interface ICollider
    /// </summary>
    public void GetHit()
    {
        Damage(damage);
    }


    private void OnTriggerEnter(Collider other)
    {
        colliderTag = other.tag;

        if (colliderTag.Equals("Bullet"))
            damage = other.GetComponent<BulletLogic>().damage;
        
        GetHit();
    }

}
