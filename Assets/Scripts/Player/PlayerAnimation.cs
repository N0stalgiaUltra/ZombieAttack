using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script usado para controlar a animação do player
/// </summary>
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    /// <summary>
    /// Chamado quando o player está se movendo
    /// </summary>
    /// <param name="value">bool que corresponde ao movimento</param>
    public void Move(bool value)
    {
        if (value)
            playerAnim.SetInteger("Move", 1);
        else
            playerAnim.SetInteger("Move", 0);
    }
    /// <summary>
    /// Chamadno quando o player recebeu dano
    /// </summary>
    public void Hurt()
    {
        playerAnim.SetTrigger("Hurt");
    }
    /// <summary>
    /// Chamado quando o player morre
    /// </summary>
    public void Die()
    {
        playerAnim.SetTrigger("Die");
    }
}
