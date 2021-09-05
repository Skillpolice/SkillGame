using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    Enemy _enemy;
    Damageable _demageable;

    [SerializeField] GameObject panel;

    [SerializeField] public static int bossCount = 2;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _demageable = GetComponent<Damageable>();

        _demageable.OnResiveBossDamage += OnResiveBossDamage;
    }

    private void Start()
    {
        panel.SetActive(false);
    }

    public void OnResiveBossDamage(float damage)
    {
        _enemy._enemyHealth -= damage;

        print("Damage");

        if (_enemy._enemyHealth <= 0)
        {
            bossCount--;
            if (bossCount <= 0)
            {
                Time.timeScale = 0;
                panel.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
            }

        }
    }
}
