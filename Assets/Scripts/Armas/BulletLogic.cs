using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script para controlar a lógica das balas, atribuindo movimento e recuperando damage.
/// </summary>
public class BulletLogic : MonoBehaviour
{
    [SerializeField] private Rigidbody rbBullet;
    [SerializeField] private float speed;
    public int damage;

    private Transform playerTransform;

    private bool isMoving;


    private void Start()
    {
        this.transform.localPosition = playerTransform.position;
        isMoving = false;
    }
    void FixedUpdate()
    {
        if (gameObject.activeSelf && !isMoving)
        {
            rbBullet.AddForce(playerTransform.transform.forward * speed, ForceMode.Impulse);
            isMoving = true;
        }

    }
    private void OnEnable()
    {
        if(!isMoving && playerTransform != null)
            this.transform.localPosition = playerTransform.position;

    }
    public void ResetVelocity()
    {
        rbBullet.velocity = Vector3.zero;
        isMoving = false;
    }

    public Transform PlayerTransform { get => this.playerTransform; set => playerTransform = value;}

}
