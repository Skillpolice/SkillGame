using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PrefabController : MonoBehaviour
{
    private void Update()
    {
        transform.DOMoveY(2, 1).SetLoops(3, LoopType.Yoyo); //повторение бесконесное
    }
}
