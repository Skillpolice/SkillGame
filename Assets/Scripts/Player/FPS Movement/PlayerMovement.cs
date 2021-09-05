using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public static PlayerMovement Instance { get; private set; }

    [Header("References")]
    [SerializeField] private CharacterController controller;

    [Header("Movement config")]
    [SerializeField] private float playerSpeed = 10f;


    [Header("Gravity")]
    [SerializeField] private float jumpHeight = 2.5f;
    [SerializeField] private float graviryScale = 0.7f;
    [SerializeField] private int ctJump = 2;
    private int currentJump;


    private bool isResetting;
    private float gravity;
    private Vector3 startPos;


    private void Start()
    {
        currentJump = ctJump;

        startPos = transform.position;
    }


    void Update()
    {
        if (isResetting)
        {
            return;
        }
        Move();
    }

    private void Move()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * inputV + transform.right * inputH;  //ƒвижение по вертикали вперед Forward и впаро Right


        if (moveDirection.sqrMagnitude > 1)
        {
            moveDirection.Normalize();
        }

        if (Input.GetButtonDown("Jump") && ctJump > 0)
        {
            ctJump--;
            gravity = jumpHeight;
        }
        else if (controller.isGrounded)
        {
            gravity = 0;
            ctJump = currentJump;
        }
        else
        {
            gravity += graviryScale * Physics.gravity.y * Time.deltaTime;
        }

        moveDirection.y = gravity;
        controller.Move(moveDirection * playerSpeed * Time.deltaTime); //Ќаправление движени€  в каждом кадре
    }


    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    Rigidbody rb = hit.collider.attachedRigidbody;

    //    if (hit.gameObject.CompareTag("Res"))
    //    {
    //        if (rb == null || rb.isKinematic)
    //        {
    //            //transform.DOMove(startPos, 1.5f).OnComplete(() => { isResetting = false; });
    //            transform.position = startPos;
    //            isResetting = false;
    //        }
    //    }
    //}

}
