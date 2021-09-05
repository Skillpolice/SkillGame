using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    public UnityEvent _OnPressed;
    public UnityEvent _OnUnPressed;

    private void OnTriggerEnter(Collider other)
    {
        _OnPressed.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        _OnUnPressed.Invoke();
    }
}
