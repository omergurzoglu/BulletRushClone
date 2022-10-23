
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootAndExplode : MonoBehaviour
{
    
    private bool _isShooting;
    private GameObject _bullet,_bullet2;
    public static readonly List<Transform> Enemies = new();
    private WaitForSeconds _fireDelay;
    [SerializeField]private Transform leftHand, rightHand,currentEnemy,currentEnemy2,lookAtEnemy;
    [SerializeField] public ParticleSystem explosionParticle,circleParticle;
    private float _lastExplosion;
    public Collider[] colliders;

    private void Awake()
    {
        colliders = new Collider[500];
        _fireDelay = new WaitForSeconds(0.09f);
        Shoot();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            circleParticle.transform.localScale += Vector3.one * (Time.deltaTime );
        }

        if (!Input.GetMouseButtonUp(0)) return;
        DestroyCircle();
        explosionParticle.Play();
        circleParticle.transform.localScale = default;
    }
    private void FixedUpdate()
    {
        if (!_isShooting) return;
        lookAtEnemy = Enemies.FirstOrDefault();
        if (lookAtEnemy == null) return;
        transform.LookAt(new Vector3(lookAtEnemy.position.x,0,lookAtEnemy.position.z));
        if (Enemies.Count == 0)
        {
            _isShooting = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer is not (3 or 7)) return;
        if (!Enemies.Contains(other.transform))
        {
            Enemies.Add(other.transform);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer is not 7) return;
        if (!Enemies.Contains(other.transform))
        {
            Enemies.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer is 3 or 7)
        {
            Enemies.Remove(other.transform);
        }
    }

    
    private void Shoot()
    {
        StartCoroutine(ShootingCoroutine());
        
    }
    
    private IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            if (Enemies.Count > 0)
            {
                
                _isShooting = true;
                currentEnemy = Enemies.First();
                currentEnemy2 = Enemies.Last();
                
                _bullet = BulletPool.instance.GetPooledBullet();
                
                if (_bullet != null)
                {
                    _bullet.transform.position = leftHand.position;
                    _bullet.transform.LookAt(new Vector3(currentEnemy.position.x,0,currentEnemy.position.z));
                    _bullet.SetActive(true);
                }
                _bullet2 = BulletPool.instance.GetPooledBullet();
               
                if (_bullet2 != null)
                {
                    _bullet2.transform.position = rightHand.position;
                    _bullet2.transform.LookAt(new Vector3(currentEnemy2.position.x,0,currentEnemy2.position.z));
                    _bullet2.SetActive(true);
                }
            }
            yield return _fireDelay;
        }
    }
    
    private void DestroyCircle()
    {
        
        var results=Physics.OverlapSphereNonAlloc(transform.position, circleParticle.transform.localScale.x, colliders,LayerMask.GetMask("Enemy"));
        for(var i=0;i<results;i++)
        {
            colliders[i].gameObject.SetActive(false);
        }
    }
    
        
    
}

