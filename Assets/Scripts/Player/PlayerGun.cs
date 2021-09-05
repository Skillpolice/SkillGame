using System;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Camera _FPSCamera;

    [Header("UI Effect")]
    public ParticleSystem muzzleFlash;
    public GameObject impactEfect;


    [Header("Gun Config")]
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _range = 50f;

    [Header("Grenade Config")]
    public GameObject grenadePrefab;
    [SerializeField] private float _throwForce = 40f;
    [SerializeField] private int _countGrenade = 2;

    int _currenGrenade;


    private void Start()
    {
        _currenGrenade = _countGrenade;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ThrowGrenade();
        }

    }

    private void ThrowGrenade()
    {
        _currenGrenade--;
        GameObject grenade = Instantiate(grenadePrefab, _FPSCamera.transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * _throwForce, ForceMode.VelocityChange);
    }

    private void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(_FPSCamera.transform.position, _FPSCamera.transform.forward, out hit, _range))
        {
            print(hit.transform.name);

            Damageable target = hit.transform.GetComponent<Damageable>();
            //Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (target != null /*|| enemy != null*/)
            {
                target.OnRecieveDamage(_damage);
                //enemy.RecieveDamage(_damage);
            }

            GameObject impact = Instantiate(impactEfect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);

        }

    }
}
