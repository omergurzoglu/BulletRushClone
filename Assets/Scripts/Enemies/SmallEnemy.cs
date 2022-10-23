

using UnityEngine;

public class SmallEnemy : EnemyManager,Idamagable
{
    private int _smallHealth;
    //private ParticleSystem _particleSystem;
    public GameObject deathParticlePrefab;
    private float smallDropChance;

    private void OnEnable()
    {
        
        _smallHealth = data.health;
        //_particleSystem = GetComponent<ParticleSystem>();
    }
    
    public void TakeDamage()
    {
        _smallHealth--;
        //_particleSystem.Play();
        
        
        if (_smallHealth <= 0)
        {
            smallDropChance = Random.value;
            DropMoneyOnDeath(smallDropChance);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        
        var particle=Instantiate(deathParticlePrefab,transform.position,Quaternion.identity);
        particle.SetActive(true);
        Destroy(particle,1f);
        ShootAndExplode.Enemies.Remove(transform);
    }
}
