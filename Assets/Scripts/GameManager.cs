using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool _isCursorLocked = false;

    void Start()
    {
        _isCursorLocked = true;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
            _isCursorLocked = true;
        if (Input.GetKey(KeyCode.Escape))
            _isCursorLocked = false;
        if (_isCursorLocked)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
}
