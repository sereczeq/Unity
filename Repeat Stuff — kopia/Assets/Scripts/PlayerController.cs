using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float liftingForce;

    public int jumps;
    public int maxJumps;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.inGame) return;

        jump();
    }

    //Metoda zostanie automatycznie wywołana w momencie zderzenia z jakimkolwiek
    //colliderem na którym ustawione jest pole IsTrigger

    private void jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (jumps < maxJumps)
            {
                jumps++;
                rb.velocity = new Vector2(0f, jumpForce);
            }
        }

        if (Input.GetMouseButton(0))
        {
            rb.AddForce(new Vector2(0f, liftingForce * Time.deltaTime));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //sprawdzamy czy zderzyliśmy się z przeszkodą
        if (other.CompareTag("Obstacle"))
        {
            //Wywołujemy metodę odpowiedzialną za śmierć gracza
            PlayerDeath();
        }
        else if(other.CompareTag("Coin"))
        {
            GameManager.instance.CoinCollected();

            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumps = 0;
    }
    void PlayerDeath()
    {
        //Zamrażamy fizykę gracza (pozostanie on wtedy w miejscu w którym przegrał
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        //Wywołujemy Game Over na managerze gry:
        GameManager.instance.GameOver();
    }

}