using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        DestroyBullet();
    }

    public void DestroyBullet()
    {
        // for now just directly destroy the bullet
        Destroy(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
