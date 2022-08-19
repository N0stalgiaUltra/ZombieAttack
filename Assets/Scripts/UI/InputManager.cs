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
public class InputManager : MonoBehaviour, IPointerUpHandler, IPointerDownHandler , IDragHandler
{

    [SerializeField] private RectTransform movementJoystick;

    [Header("JoystickProperties")]
    [SerializeField]
    private float dragThreshold = 0.6f;
    [SerializeField]
    private int dragMovementDistance = 30;
    [SerializeField]
    private int dragOffsetDistance = 100;


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

    [Header("Action Buttons")]
    [SerializeField] private Button shootButton;
    [SerializeField] private Button pickButton;
    [SerializeField] private Button healButton;
    [SerializeField] private Button aimButton;

    private void Start()
    {
        shootButton.onClick.AddListener(ShootClicked);
        healButton.onClick.AddListener(HealClicked);
        pickButton.onClick.AddListener(PickClicked);
        aimButton.onClick.AddListener(AimClicked);
        
    }

    #region Movimento via AnalogStickUI
    /// <summary>
    /// Utilizado quando o analog stick é solto, resentando as posições.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        movementJoystick.anchoredPosition = Vector3.zero;
        OnMove?.Invoke(Vector3.zero);
    }

    /// <summary>
    /// Utilizado para fazer o movimento do drag do analog stick e também atribuir movimento ao player via evento
    /// </summary>
    /// <param name="eventData">Dados do objeto a ser manipulado, no caso, o stick menor (branco)</param>
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            movementJoystick,
            eventData.position,
            eventData.pressEventCamera,
            out offset
            );
        offset = Vector2.ClampMagnitude(offset, dragOffsetDistance) / dragOffsetDistance;
        movementJoystick.anchoredPosition = offset * dragMovementDistance;
        
        moveInput = MovementInput(offset);
        OnMove?.Invoke(moveInput);
    }

    /// <summary>
    /// Usado somente para não travar o analog stick em uma posição
    /// </summary>
    /// <param name="eventData">dados do objeto a ser controlado, no caso, stick menor</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    /// <summary>
    /// Método responsável por calcular e retornar um Vector3 para movimentar o player
    /// </summary>
    /// <param name="offset">deslocamento do stick</param>
    /// <returns></returns>
    public Vector3 MovementInput(Vector2 offset)
    {
        float x = Mathf.Abs(offset.x) > dragThreshold ? offset.x : 0;
        float z = Mathf.Abs(offset.y) > dragThreshold ? offset.y : 0;
        return new Vector3(x, 0, z);
    }
    #endregion

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
