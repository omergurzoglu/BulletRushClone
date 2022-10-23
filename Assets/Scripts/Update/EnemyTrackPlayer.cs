

using UnityEngine;
public class EnemyTrackPlayer : MonoBehaviour
{
    [SerializeField]private Transform playerPos;
    [SerializeField]private float speedConstant=150f;
    
    private Rigidbody _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        
    }
    private void FixedUpdate()
    {
        TrackPlayer();
    }

    private void TrackPlayer()
    {
        transform.LookAt(new Vector3(playerPos.position.x,transform.position.y,playerPos.position.z));
        _rb.velocity = transform.forward * (Time.fixedDeltaTime * speedConstant);
    }
    
}
