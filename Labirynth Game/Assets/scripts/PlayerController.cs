using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //moving
    public float speed = 12f;
    public float gravity = -10f;
    CharacterController characterController;

    //groundCheck
    public Transform groundCheck;
    public LayerMask ground;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        //Debug.Log(transform.right);
        // getAxis zwraca w tym przypadku trzy wartości: -1, 0, 1
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //transform.right - trójwymiarowy wektor wskazujący zawsze w prawo względem obiektu
        Vector3 velocity = transform.right * speed  * x + transform.forward * speed  * z;
        velocity.y += gravity;

        //Time.deltaTime - aby ilość klatek nie robiła różnicy w prędkości postaci
        characterController.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pickup"))
        {
            other.gameObject.GetComponent<Pickup>().Picked();
        }
    }
}

