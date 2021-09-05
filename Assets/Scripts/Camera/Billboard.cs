using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform _cam;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _cam.forward);

    }
}
