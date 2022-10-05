//using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script usado para movimentar o player
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header ("Components References")]
    [SerializeField] private Rigidbody rb;

    [Header("Variables References")]
    [SerializeField] private float movementVelocity;
    
    [Header ("Script References")]
    [SerializeField] private PlayerAnimation playerAnim;
    private RaycastHit hit;

    /// <summary>
    /// Metodo usado para movimentar o player
    /// </summary>

    private void Start()
    {
        MovingState.OnMove += Move;
    }
    private void Move()
    {
        //chama o evento
        //muda animação para correr

        float movx = Input.GetAxis("Horizontal");
        float movz = Input.GetAxis("Vertical");

        if (Mathf.Abs(movx) > Mathf.Epsilon || Mathf.Abs(movz) > Mathf.Epsilon)
        {
            playerAnim.Move(true);
        }
        else
            playerAnim.Move(false);

        rb.velocity = new Vector3 (movx * movementVelocity, 0, movz * movementVelocity);

    }


    // TODO: melhorar a rotação junto do mouse.
    private void Rotate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit))
            return;

        Vector3 targetRot = ray.GetPoint(hit.distance);
        transform.LookAt(new Vector3 (targetRot.x, transform.position.y, targetRot.z));
    }
    private void Update()
    {
        Rotate();

    }
    void FixedUpdate()
    {
        #region Quando instalar o Photon
        //if(view.IsMine)
        //rb.velocity = movement * movementVelocity;
        #endregion
        
    }

    
}
