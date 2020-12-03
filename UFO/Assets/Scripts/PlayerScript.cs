using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    Rigidbody2D rb2d;
    public float speed = 5f;

    int punkty = 0;
    public Text tekstWynik;
    public Text tekstWygrales;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tekstWygrales.text = "";
        tekstWynik.text = "wynik: 0";

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D obiekt)
    {
        if (obiekt.gameObject.CompareTag("PickUp"))
        {
            obiekt.gameObject.SetActive(false);
            setText();
        }
    }

    void setText()
    {
        if (punkty == 6)
        {
            tekstWygrales.text = "Super, wygrałeś";
        }
        punkty++;
        tekstWynik.text = "Wynik: " + punkty.ToString();
    }

}
