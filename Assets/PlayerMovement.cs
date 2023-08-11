using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float mouseSensitivity = 1;
    public float speed = 10;
    float _xRot = 0; // the rotation of the camera around the x axis

    public Camera playerCamera;

    CharacterController _controller;

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
    }
}
