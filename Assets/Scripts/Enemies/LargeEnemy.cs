using UnityEngine;

namespace Enemies
{
    public class LargeEnemy : EnemyManager,Idamagable
    {
        private int _largeHealth;
        private ParticleSystem _particleSystem;
        public Material material;
        public GameObject deathParticlePrefab;

        private void Awake()
        {

            material.color = Color.cyan;

        }

        private void OnEnable()
        {
        
            _largeHealth = data.health;
            _particleSystem = GetComponent<ParticleSystem>();
        }

        public void TakeDamage()
        {
            DownScale();
            material.color = Color.Lerp(material.color, new Color(0,0.5f,0), 0.008f);
            _particleSystem.Play();
            _largeHealth--;
            if (_largeHealth > 0) return;
            //DropMoneyOnDeath();
            gameObject.SetActive(false);
        }

        private void DownScale()
        {
            transform.localScale -= Vector3.one * 0.02f;
            transform.position += Vector3.down * 0.02f;
        }
        private void OnDisable()
        {
            var particle=Instantiate(deathParticlePrefab,transform.position,Quaternion.identity);
            particle.SetActive(true);
            Destroy(particle,1f);
            ShootAndExplode.Enemies.Remove(transform);
        }
    }
}
