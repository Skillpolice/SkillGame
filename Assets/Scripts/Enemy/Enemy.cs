using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Damageable))]
public class Enemy : MonoBehaviour
{
    Animator _anim;
    Collider _coll;
    Damageable _damageable;


    [Header("Enemy UI")]
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private GameObject _prefHealth;
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private GameObject _enemyShootPos;

    [Header("Enemy Config")]
    [SerializeField] public float _enemyHealth = 100;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _coll = GetComponent<Collider>();
        _damageable = GetComponent<Damageable>();
    }

    private void Start()
    {

        _healthBar.setMaxHealth(_enemyHealth);
        _damageable.OnRecieveDamage += RecieveDamage;

    }


    public void EnemyShooting()
    {
        Instantiate(_bulletPref, _enemyShootPos.transform.position, Quaternion.identity);
    }

    public void RecieveDamage(float damage)
    {
        _enemyHealth -= damage;
        _healthBar.SetHealth(_enemyHealth);
        _anim.SetTrigger("EnemyHit");

        if (_enemyHealth <= 0)
        {
            _anim.SetTrigger("EnemyDead");
            _coll.enabled = false;

            Instantiate(_prefHealth, transform.position * 1f, Quaternion.identity);
            Destroy(gameObject, 5f);
        }
    }




}
