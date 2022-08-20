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
    Vector3 movement;
    [SerializeField] float rotationSpeed;

    [SerializeField] private bool lockRotationX;
    [SerializeField] private bool lockRotationZ;
    private RaycastHit hit;
    void Start()
    {
        //InputManager.OnMove += Move;
    }

    /// <summary>
    /// Metodo usado para movimentar o player
    /// </summary>
    /// <param name="movementInput">vetor de 3 dimensões recebidos do input, usados para movimentar o player</param>
    private void Move(Vector3 movementInput)
    {
        #region Quando instalar o Photon
        //if (view.IsMine)
        //{
        //    movement = movementInput;
        //    if (Mathf.Abs(movementInput.x) > Mathf.Epsilon || Mathf.Abs(movementInput.z) > Mathf.Epsilon)
        //    {
        //        playerAnim.Move(true);
        //    }
        //    else
        //        playerAnim.Move(false);

        //    if (movement != Vector3.zero)
        //    {
        //        Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
        //        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        //    }
        //}
        #endregion

        movement = movementInput;
        if (Mathf.Abs(movementInput.x) > Mathf.Epsilon || Mathf.Abs(movementInput.z) > Mathf.Epsilon)
        {
            playerAnim.Move(true);
        }
        else
            playerAnim.Move(false);

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }

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

    private void OnDisable()
    {
        //InputManager.OnMove -= Move;
    }
}
