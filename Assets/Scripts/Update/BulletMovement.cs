
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody rb;
    private TrailRenderer _trail;
   
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _trail = GetComponent<TrailRenderer>();
    }
    
    private void OnDisable()
    {
        _trail.Clear();
        
     }

    private void Update()
    {
        transform.Translate(transform.forward * (Time.deltaTime * 60f),Space.World);
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        
        if(collision.gameObject.layer is 3 or 7)
        {
            
            var damageable = collision.gameObject.GetComponent<Idamagable>();
            damageable.TakeDamage();
            gameObject.SetActive(false);
            
        }
        if (collision.gameObject.layer != 8) return;
        gameObject.SetActive(false);

    }

   
}
