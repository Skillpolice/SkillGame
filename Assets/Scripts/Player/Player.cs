using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Damageable damageable;
    [SerializeField] public static Player Instance { get; private set; }
    //[SerializeField] private Light _lightMore;

    [Header("Player UI")]
    [SerializeField] public HealthBar _healthBar;
    [SerializeField] private float _playerHealth = 100f;


    private bool isResetting;
    public Vector3 startPos;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        damageable = GetComponent<Damageable>();
    }

    private void Start()
    {
        _healthBar.setMaxHealth(_playerHealth);
        damageable.OnRecieveDamage += DoDamage;

    }

    public void DoTakeHealth(float health)
    {
        _playerHealth += health;
        _healthBar.SetHealth(_playerHealth);
    }

    public void DoDamage(float damage)
    {
        _playerHealth -= damage;
        _healthBar.SetHealth(_playerHealth);

        if(_playerHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (hit.gameObject.CompareTag("ResPlane"))
        {
            if (rb == null || rb.isKinematic)
            {
                //transform.DOMove(startPos, 1.5f).OnComplete(() => { isResetting = false; });
                transform.position = startPos;
                isResetting = false;
            }
        }
    }

    //private void TorchLight()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        if (_lightMore.enabled == false)
    //        {
    //            _lightMore.enabled = true;
    //        }
    //        else
    //        {
    //            _lightMore.enabled = false;
    //        }
    //    }
    //}
}
