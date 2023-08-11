using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{

    public Transform shootOrigin;
    public GameObject bullet;
    public float shootForce = 10;
    public float coolDownDuration = 0.1f;
    public float bulletDuration = 1;
    float _coolDown = 0;

    void Shoot()
    {
        GameObject b = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
        b.transform.position = shootOrigin.position;
        Rigidbody rb = b.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Time.deltaTime * shootForce, ForceMode.VelocityChange);
        Destroy(b, bulletDuration);
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (_coolDown == 0)
            {
                Shoot();
                _coolDown += coolDownDuration;
            }
        }
        if (_coolDown > 0)
            _coolDown -= Time.deltaTime;
        if (_coolDown < 0)
            _coolDown = 0;
    }
}
