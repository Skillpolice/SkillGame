using UnityEngine;
using UnityEngine.Events;

public class TurretActivade : MonoBehaviour
{
    public UnityEvent _OnPressed;

    private void OnTriggerEnter(Collider other)
    {
        _OnPressed.Invoke();
    }
}
