using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    private CharacterController _chracterController;

    // Start is called before the first frame update
    void Start()
    {
        _chracterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame

    void Update()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }


        if (Input.GetKeyDown(KeyCode.Space) && _chracterController. isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }


    void FixedUpdate()
    {
        _chracterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _chracterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if(_chracterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
