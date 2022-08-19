using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script para controlar o colisor das balas
/// </summary>
public class BulletCollider : MonoBehaviour, ICollider
{
    /// <summary>
    /// Implementação do contrato da interface ICollider
    /// </summary>
    public void GetHit()
    {
        DeactivateBullet();
    }

    //private void OnBecameInvisible() => DeactivateBullet();

    /// <summary>
    /// Metodo para desativar a bala e retornar ela para o Pool
    /// </summary>
    private void DeactivateBullet()
    {
        this.gameObject.SetActive(false);
        BulletPooling.instance.ReplenishQueue(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        GetHit();
    }

}
