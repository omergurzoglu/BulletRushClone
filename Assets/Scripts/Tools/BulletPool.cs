
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;
    private readonly List<GameObject> _pooledBullets = new();
    private const int BulletAmount = 40;
    [SerializeField] private GameObject bulletPrefab;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (var i = 0; i < BulletAmount; i++)
        {
            var obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            _pooledBullets.Add(obj);
        }
    }

    public GameObject GetPooledBullet()
    {
        for (var i = 0; i < _pooledBullets.Count; i++)
        {
            if (!_pooledBullets[i].activeInHierarchy)
            {
                return _pooledBullets[i];
            }
            
        }
        return null;
    }
}
