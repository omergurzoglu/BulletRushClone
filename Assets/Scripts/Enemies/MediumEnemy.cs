using UnityEngine;

public class MediumEnemy : EnemyManager,Idamagable
{
    private int _mediumHealth;
    private ParticleSystem _particleSystem;
    public Material material;
    public GameObject deathParticlePrefab;

    private void Awake()
    {
        material.color = Color.cyan;
    }

    private void OnEnable()
    {
        _mediumHealth = data.health;
        _particleSystem = GetComponent<ParticleSystem>();
    }
    
    public void TakeDamage()
    {
        DownScale();
        material.color = Color.Lerp(material.color, new Color(0,0.5f,0), 0.08f);
        _particleSystem.Play();
        _mediumHealth--;
        if (_mediumHealth > 0) return;
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
