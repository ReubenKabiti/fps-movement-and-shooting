using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    float _health = 100;
    public float bulletDamage = 10;
    public GameObject healthBar;
    public GameObject exploder;

    ParticleSystem _particleSystem;
    Material material;
    Animator animator;
    float duration;

    void Start()
    {
        MeshRenderer mr = healthBar.GetComponent<MeshRenderer>();
        material = mr.material;
        _particleSystem = exploder.GetComponent<ParticleSystem>();
        duration = _particleSystem.main.startLifetime.constantMax;
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            _health -= bulletDamage;
            if (_health <= 0)
                animator.SetBool("shouldDie", true);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        float t = _health/100.0f;
        Color color = Color.Lerp(new Color(0, 0, 0, 0), Color.red, t);
        material.color = color;
    }
}
