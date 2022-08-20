using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
/// <summary>
/// Usado para controlar o input de UI na cena
/// </summary>
public class InputManager : MonoBehaviour
{

    #region Events
    private Vector3 moveInput;
    public static event Action<Vector3> OnMove;

    public delegate void ShootAction();
    public static event ShootAction playerShooted;

    public delegate void PickUpAction();
    public static event PickUpAction playerPicked;
    
    public delegate void AutoAimAction();
    public static event AutoAimAction playerAimed;
    
    public delegate void HealAction();
    public static event HealAction playerHealed;
    #endregion



    private void Start()
    {

    }
    private void Update()
    {
        /* Introduzir esquema de botões */
        if (Input.GetKeyDown(KeyCode.E))
            PickClicked();

        if (Input.GetButtonDown("Fire1"))
            ShootClicked();

    }

    #region Ação dos Botões de Tiro/Pegar arma e Cura
    private void ShootClicked()
    {
        playerShooted?.Invoke();
    }

    private void HealClicked()
    {
        playerHealed?.Invoke();
    }

    private void PickClicked()
    {
        playerPicked?.Invoke();
    }
    private void AimClicked()
    {
        playerAimed?.Invoke();
    }
    #endregion
}
