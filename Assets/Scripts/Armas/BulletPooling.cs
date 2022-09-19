using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script para fazer o pooling das balas
/// </summary>
public class BulletPooling : MonoBehaviour
{

    //[SerializeField] private BulletLogic bulletPrefab;
    [SerializeField] private BulletFactory _bulletFactory;

    [SerializeField] private Queue<BulletLogic> bulletQueue = new Queue<BulletLogic>(35);
    int capacity = 35;
    

    public static BulletPooling instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
            instance = this;

        for (int i = 0; i < capacity; i++)
        {
            //BulletLogic bulletLogic = _bulletFactory.GetNewInstance();
            //bulletLogic.gameObject.SetActive(false);
            //bulletQueue.Enqueue(bulletLogic);
            bulletQueue.Enqueue(_bulletFactory.GetNewInstance());
        }
    }

    /// <summary>
    /// Usado para retirar um objeto da fila e ativá-lo na cena
    /// </summary>
    /// <param name="bulletSpawn"> transform que vai ser referencia para a instância </param>
    /// <returns></returns>
    public BulletLogic BulletSpawn(Transform bulletSpawn)
    {
        if (bulletQueue.Count != 0)
        {
            BulletLogic aux = bulletQueue.Dequeue();
            aux.gameObject.GetComponent<BulletLogic>().playerTransform = bulletSpawn;
            aux.damage = bulletSpawn.GetComponentInParent<GunLogic>().Damage;
            

            aux.gameObject.SetActive(true);
            return aux;
        }
        else
        {
            Debug.LogError("Fila de objetos vazia");
            return null;
        }

    }

    /// <summary>
    /// Usado para repor os objetos na fila
    /// </summary>
    /// <param name="bulletObject">objeto a ser adicionado</param>
    public void ReplenishQueue(GameObject bulletObject)
    {
        if (bulletQueue.Count != capacity)
        {
            BulletLogic aux = bulletObject.GetComponent<BulletLogic>();
            bulletObject.SetActive(false);
            bulletQueue.Enqueue(aux);
        }
        else
            return ;
    }
}
