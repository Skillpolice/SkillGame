using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickUpPharmacy : MonoBehaviour
{
    [SerializeField] private float _playerHealthUp = 10f;

    private void Start()
    {
        transform.DOMoveY(2, 1f).SetLoops(-1, LoopType.Yoyo); //повторение бесконесное
    }

    private void Applayeffect()
    {
        Player.Instance.DoTakeHealth(_playerHealthUp);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("triger");

        if (other.gameObject.CompareTag("Player"))
        {
            Applayeffect();
            Destroy(gameObject);
        }
    }

}
