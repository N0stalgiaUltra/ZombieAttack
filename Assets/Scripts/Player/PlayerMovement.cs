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
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementVelocity;

    [SerializeField] private PlayerAnimation playerAnim;

    //[SerializeField] private PhotonView view;

    private RaycastHit hit;

    /// <summary>
    /// Metodo usado para movimentar o player
    /// </summary>
    private void Move()
    {
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

    private void Rotate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit))
            return;

        Vector3 targetRot = ray.GetPoint(hit.distance);
        transform.LookAt(new Vector3 (targetRot.x,transform.position.y, targetRot.z));

    }
    void FixedUpdate()
    {
        #region Quando instalar o Photon
        //if(view.IsMine)
        //rb.velocity = movement * movementVelocity;
        #endregion
        
        Move();
        Rotate();
    }

}
