using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float mouseSensitivity = 1;
    public float speed = 10;

    float _xRot = 0; // the rotation of the camera around the x axis
    CharacterController _controller;


    // falling and jumping
    public float gravityStrength = 9.8f;
    public float jumpStrength = 10.1f;
    Vector3 _velocity = Vector3.zero;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // looking around
        // camera

        _xRot -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        _xRot = Mathf.Clamp(_xRot, -90, 90);
        Vector3 cameraRot = playerCamera.transform.rotation.eulerAngles;
        cameraRot.x = _xRot;
        playerCamera.transform.rotation = Quaternion.Euler(cameraRot);

        // the player

        float yRot = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(0, yRot, 0);


        // movement

        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        Vector3 move = transform.right * xMove + transform.forward * yMove;
        move *= speed * Time.deltaTime;
        _controller.Move(move);


        // jumping and falling
        _controller.Move(_velocity * Time.deltaTime);
        if (_controller.isGrounded)
        {
            _velocity.y = 0;
            if (Input.GetButton("Jump"))
            {
                _velocity.y += jumpStrength;
            }
        }
        else
        {
            _velocity.y -= gravityStrength * Time.deltaTime;
        }
    }
}
