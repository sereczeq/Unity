using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float rotateSpeed = 1f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();
        Animate();
    }

    void Animate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                                             transform.position.z + movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                                             transform.position.z - movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime,
                                             transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime,
                                             transform.position.y, transform.position.z);
        }
    }
    
    void Rotate()
    {

        // tworzenie powierzchni równoległej do podłogi, ze środkiem na pozycji gracza
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // tworzenie promienia wychodzącego z kamery, idącego do myszki
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // zmienna przechowująca odległość
        float hitDistance = 0f;
        // sprawdzanie, czy promień uderza w playerPlane
        if(playerPlane.Raycast(ray, out hitDistance))
        {
            // wczytanie punktu zetknięcia promienia z playerPlane
            Vector3 targetPoint = ray.GetPoint(hitDistance);


            // obliczanie końcowej (tej którą chcemy uzyskać) rotacji gracza
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            
            // obracanie gracza powoli (płynnie) do targetRotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                                                                    rotateSpeed * Time.deltaTime);
        }
    }

}
