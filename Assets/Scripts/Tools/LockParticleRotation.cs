
using UnityEngine;

public class LockParticleRotation : MonoBehaviour
{
    
    private void Update()
    {
        var rotation = Quaternion.LookRotation(Vector3.up , Vector3.forward);
        transform.rotation = rotation;
    }
}
