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

    public Transform playerTransform;

    private void Start()
    {
        if (gameObject.activeSelf)
            damage = gameObject.GetComponentInParent<GunLogic>().Damage;
    }
    void FixedUpdate()
    {
        if(gameObject.activeSelf)
            rbBullet.AddForce(playerTransform.transform.forward * speed, ForceMode.Impulse);
    }
}
