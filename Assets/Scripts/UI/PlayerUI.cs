using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Script usado apra controlar a UI do player
/// </summary>
public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private TextMeshProUGUI reloadingText;
  

    void Start()
    {
        healthBar.fillAmount = playerHealth.HealthPlayer / playerHealth.TotalHealt;
        playerHealth.healthChanged += HealthChanged;
        reloadingText.enabled = false;

    }

    private void Update()
    {
        reloadingText.enabled = GunLogic.reloading;
    }
    /// <summary>
    /// Usado para atualizar a barra vida do player
    /// </summary>
    void HealthChanged()
    {
        healthBar.fillAmount = (float)playerHealth.HealthPlayer / playerHealth.TotalHealt;
    }
}
