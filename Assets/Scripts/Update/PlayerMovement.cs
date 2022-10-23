
using System;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private FloatingJoystick floatingJoystick ;
    [SerializeField] private float speedConstant;
    private Vector3 _direction,_position;
    private float _horizontalInput,_verticalInput;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            JoystickMovement();
           
        }
    }
     private void JoystickMovement()
    {
        _horizontalInput = floatingJoystick.Horizontal;
        _verticalInput = floatingJoystick.Vertical;
        
        _position=new Vector3(_horizontalInput*speedConstant*Time.fixedDeltaTime,0,_verticalInput*speedConstant*Time.fixedDeltaTime);
        _rb.velocity += _position;
        
        _direction = Vector3.forward * _verticalInput + Vector3.right * _horizontalInput;
        _rb.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(_direction),10f*Time.fixedDeltaTime);
    }

     private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.layer is 3 or 7)
         {
             GameManager.Instance.GameOver();
         }
     }
}
