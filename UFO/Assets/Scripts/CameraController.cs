using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject Player;
    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - Player.transform.position;
        //odejmujemy pozycję kamery od pozycji Gracza na początku
    }

    // Update is called once per frame 
    void Update()
    {
        transform.position = Player.transform.position + offset;
        //update jest co klatę wywolywny na sam koniec, jak wszystkie obiekty sa juz narysowane
        //więc dzięki temu, ze mamy
        //zapisany offest czyloi początkową różnice, 
        //możmey nadawać kamerze co kratkę taką samą pozycję, tzn roznice pomiędzy położeniem gracza i kamery
        //dzięki tamu bedzie zludzenie, ze kamera podąza za graczem
    }
}

