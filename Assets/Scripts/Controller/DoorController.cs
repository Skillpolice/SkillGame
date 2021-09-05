using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    [SerializeField] ButtonController _button;


    [Header("Door UI")]
    [SerializeField] private float speedDoor = 10f;
    [SerializeField] private float upDoor = 10f;
    [SerializeField] private float downDoor = 10f;
    //[SerializeField] private float timeCoroutine = 2f;


    public void ActivatedUp()
    {
        //StopAllCoroutines();
        //StartCoroutine(GoUp());

        //animator.SetTrigger("GoUp");

        transform.DOMoveY(upDoor, speedDoor);
    }


    public void ActivatedDown()
    {
        //StopAllCoroutines();
        //StartCoroutine(GoDown());

        //animator.SetTrigger("GoDown");

        transform.DOMoveY(downDoor, speedDoor);
    }

    //IEnumerator GoUp()
    //{
    //    while (transform.position.y < 10)
    //    {
    //        transform.position += Vector3.up * speedDoor * Time.deltaTime; //door UP
    //        yield return null;
    //    }
    //}

    //IEnumerator GoDown()
    //{
    //    yield return new WaitForSeconds(timeCoroutine);

    //    while (transform.position.y > 0)
    //    {
    //        transform.position -= Vector3.up * speedDoor * Time.deltaTime; //door down
    //        yield return null;
    //    }
    //}


}
