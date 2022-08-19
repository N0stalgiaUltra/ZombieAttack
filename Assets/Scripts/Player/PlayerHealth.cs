using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script usado para controlar a vida do player
/// </summary>
public class PlayerHealth : MonoBehaviour, IHealth
{
    private PlayerAnimation playerAnimation;
    private int playerHealth;
    private readonly int totalHealth = 200;
    public int health => playerHealth;

    public delegate void OnHealthChange();
    public event OnHealthChange healthChanged;
    private void Awake()
    {
        playerHealth = totalHealth;
        playerAnimation = GetComponent<PlayerAnimation>();
    }
    private void Update()
    {
        if (playerHealth <= 0)
            Die();
    }
    /// <summary>
    /// Metodo implementado da interface IHealth, usado para atribuir dano ao player
    /// </summary>
    /// <param name="value">valor a ser subtraido da vida do player</param>
    public void Damage(int value)
    {
        if (playerHealth > 0)
            playerHealth -= value;
        else
            Die();

        playerAnimation.Hurt();
        healthChanged?.Invoke();
        print($"Player perdeu {value} de HP");
    }
    /// <summary>
    /// Chamado quando o player morre
    /// </summary>
    public void Die()
    {
        playerAnimation.Die();
        GameManager.instance.GameOver(false);
        playerHealth = totalHealth;
    }
    /// <summary>
    /// Usado para curar o player
    /// </summary>
    /// <param name="value">valor a ser acrescentado a vida do player</param>
    public void Heal(int value)
    {
        if (playerHealth > 0)
            playerHealth += value;
    }
    public int HealthPlayer { get => playerHealth; }
    public int TotalHealt { get => totalHealth; }
}
