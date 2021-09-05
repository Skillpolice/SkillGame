using System;
using UnityEngine;

[RequireComponent(typeof(Damageable))]
public class Turret : MonoBehaviour
{
    Damageable damageable;

    [Header("Terret UI")]
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private ParticleSystem _deathEffect;
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private GameObject _shootPos;
    private Transform _targer;

    [Header("Terret Config")]
    [SerializeField] private Transform _head;
    [SerializeField] private float _speedRotate = 0.5f;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _attackRadius = 10f;
    [SerializeField] private float _turretHealth = 100f;


    float _distanceToPlayer;

    private void Awake()
    {
        damageable = GetComponent<Damageable>();
    }

    private void Start()
    {
        _targer = FindObjectOfType<Player>().transform;

        healthBar.setMaxHealth(_turretHealth);
        damageable.OnRecieveDamage += TurretDoDamage;

        gameObject.SetActive(false);
    }

    private void Update()
    {

        Rotate();

        _fireRate -= Time.deltaTime;
        if (_fireRate <= 0)
        {
            _fireRate = 1f;
            Shoot();
        }

    }

    public void TurretDoDamage(float damage)
    {
        _turretHealth -= damage;
        healthBar.SetHealth(_turretHealth);

        if (_turretHealth <= 0)
        {
            Destroy(gameObject,1f);

            Instantiate(_deathEffect, transform.position, Quaternion.identity);
        }
    }

    private void Rotate()
    {

        Vector3 dir = (_targer.position - _head.position);
        Vector3 stepDir = Vector3.RotateTowards(_head.forward, dir, _speedRotate * Time.deltaTime, 0f);

        _head.rotation = Quaternion.LookRotation(stepDir);
    }

    private void Shoot()
    {
        _distanceToPlayer = Vector3.Distance(transform.position, Player.Instance.transform.position);

        if (_distanceToPlayer < _attackRadius)
        {
            Instantiate(_bulletPref.transform, _shootPos.transform.position, Quaternion.identity);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}
