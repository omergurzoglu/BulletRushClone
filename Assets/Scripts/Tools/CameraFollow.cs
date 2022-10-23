
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 _offset,_targetPos;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothness;
    private Vector3 _velocity = Vector3.zero;

    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        _targetPos = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, _targetPos, ref _velocity, smoothness);
    }
}
