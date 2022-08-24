using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script para controlar a l�gica das balas, atribuindo movimento e recuperando damage.
/// </summary>
public class BulletLogic : MonoBehaviour
{
    [SerializeField] private Rigidbody rbBullet;
    [SerializeField] private float speed;
    public int damage;

    public Transform playerTransform;

    private void Start()
    {
        transform.localPosition = playerTransform.position;
        transform.rotation = playerTransform.rotation;

    }
    void FixedUpdate()
    {
        if (gameObject.activeSelf)
            rbBullet.AddForce(transform.forward * speed, ForceMode.Impulse);

    }
}
