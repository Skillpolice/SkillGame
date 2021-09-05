using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    Damageable damageable;

    [SerializeField] private float _bulletDamage = 10f;
    [SerializeField] private float _bulletSpeed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        damageable = GetComponent<Damageable>();

        Vector3 bulletAccuracy = new Vector3(Random.Range(0, 0.5f), Random.Range(0, 0.5f), Random.Range(0, 0.5f)); //Стрельба вокруг области центра Игрока
        Vector3 direction = (Player.Instance.transform.position - transform.position) + bulletAccuracy;

        rb.AddForce(direction * _bulletSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.Instance.DoDamage(_bulletDamage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible() //Уничтожение обьектов за пределы камеры
    {
        if (gameObject.activeSelf)
        {
            Destroy(gameObject, 10f);
        }

    }

}
