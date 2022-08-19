using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script usado para criar o SO de inimigo
/// </summary>
[CreateAssetMenu(menuName = "Assets/Create Enemy")]
public class EnemyData : ScriptableObject
{
    public int health;
    public int damage;
    public float speed;
    public float attackRate;
    public float spawnPercentage;
    public int score;
    public GameObject prefab;
}
