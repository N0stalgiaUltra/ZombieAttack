using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour, IGenericFactory<BulletLogic>
{

    [SerializeField] private BulletLogic _bulletPrefab;

    public BulletLogic GetNewInstance()
    {
        BulletLogic obj = Instantiate(_bulletPrefab, transform);
        obj.gameObject.SetActive(false);
        return obj; 
    }
    
}
