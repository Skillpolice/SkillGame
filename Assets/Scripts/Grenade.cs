using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public ParticleSystem exlposionEffect;

    [Header("Grenade config")]
    [SerializeField] private float _grenadeDamage = 50f;
    [SerializeField] private float _delay = 3f;
    [SerializeField] private float _radiusExplode = 10f;
    [SerializeField] private float _force = 700f;


    float _countDown;
    bool _hasExploded = false;

    private void Start()
    {
        _countDown = _delay;
    }


    private void Update()
    {
        _countDown -= Time.deltaTime;

        if (_countDown <= 0f && !_hasExploded)
        {
            Explode();
            _hasExploded = true;
        }
    }

    private void Explode()
    {
        Instantiate(exlposionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusExplode);

        foreach (Collider item in colliders)
        {
            Damageable en = item.GetComponent<Damageable>();
           
            if (en != null)
            {
                en.OnRecieveDamage(_grenadeDamage);
                
            }
        }

        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(_force, transform.position, _radiusExplode);
            }

        }


        Destroy(gameObject);
    }
}
