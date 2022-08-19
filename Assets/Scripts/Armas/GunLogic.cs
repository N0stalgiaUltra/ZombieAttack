using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// Script para controlar a lógica das armas
/// </summary>
public class GunLogic : MonoBehaviour
{
    [SerializeField] private Gun gunData;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private ParticleSystem muzzleFire;
    [SerializeField] private Collider gunCollider;

    public static bool reloading;
    private int ammo;
    private float nextFire;
    private bool canShoot;
    public int Damage { get => gunData.damage; }
    void Start()
    {
        nextFire = 0f;
        ammo = gunData.ammo;
        reloading = false;
    }
    private void Update()
    {
        if (Time.time > nextFire)
        {
            canShoot = true;
            nextFire = Time.time + gunData.fireRate;
        }
    }
    /// <summary>
    /// Usado para fazer o player atirar
    /// </summary>
    public void Shoot() {

        if (ammo > 0 && canShoot)
        {
            BulletPooling.instance.BulletSpawn(bulletSpawn);
            muzzleFire.Play();
            ammo--;
            canShoot = false;
        }
        else if (ammo <= 0)
            StartCoroutine(Reload());

    }

    /// <summary>
    /// Usado para recarregar a arma do player.
    /// </summary>
    /// <returns>Espera o tempo de reload e retorna com o numero de munições.</returns>
    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(gunData.reloadTime);
        ammo = gunData.ammo;
        reloading = false;
    }

    /// <summary>
    /// Usado para desabilitar o colisor.
    /// </summary>
    public void DisableCollider()
    {
        gunCollider.enabled = false;
    }
}
