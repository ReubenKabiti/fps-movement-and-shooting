using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{

    public float epsilon = (float)1e-3;
    public bool IsOnGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Ray(transform.position, Vector3.down), out hit))
        {
            Debug.Log("Maybe hit: " + hit.distance);
            return hit.distance <= epsilon;
        }
        return false;
    }

    void Update()
    {
        Debug.Log("Is on ground: " + IsOnGround());
    }
}
