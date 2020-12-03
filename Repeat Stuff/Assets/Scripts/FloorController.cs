using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{

	//Pola do których przypisujemy duże kafelki z podłogą
	//Zakładamy, że na początku do floorTile1 jest przypisany lewy kafelek
	public GameObject floorTile1, floorTile2;

	//Tablica trzymająca wszystkie przygotowane template'y
	public GameObject[] tiles;
	public GameObject emptyTile;

    void Start()
    {
		//tworzymy dwie puste tiles na starcie gry
		floorTile1 = Instantiate(emptyTile, transform.position + new Vector3(0f, 1.6f, 0f), Quaternion.identity);
		//jedna musi być przesunięta o odpowiedni offset
		floorTile2 = Instantiate(emptyTile, transform.position + new Vector3(30.42f, 1.6f, 0f), Quaternion.identity);

		//ustalamy rodzica, nie jest to konieczne, ale ładnie wygląda w hierarchii
		floorTile1.transform.parent = gameObject.transform;
		floorTile2.transform.parent = gameObject.transform;
	}

    void FixedUpdate()
	{
		if (!GameManager.instance.inGame) return;
		//Co tick silnika fizyki przesywamy oba kafelki o worldScrolingSpeed
		// -= ponieważ chcemy przesuwać świat w lewo, czyli zmniejszać współrzędną X
		floorTile1.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed, 0f, 0f);
		floorTile2.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed, 0f, 0f);

		//Jeśli środek prawego kafelka przejechał przez środek ekranu (x < 0) lewy kafelek przenosimy
		//na jego prawą stronę i zamieniamy zmienne

		if (floorTile2.transform.position.x < 0f)
		{
			// wybieramy losowy kafelek z tablicy i ustawiamy go w odpowiednim miejscu
			var newTile = Instantiate(tiles[Random.Range(0, tiles.Length)],
				floorTile2.transform.position + new Vector3(30.42f, 0f, 0f), Quaternion.identity);

			//ustawiamy newTile na dziecko floor (ładniej wygląda w hierarchi, nie ma znaczenia na prawdę)
			newTile.transform.parent = gameObject.transform;

			//niszczymy stary floorTile
			Destroy(floorTile1);

			//aktualizujemy zmienne
			floorTile1 = floorTile2;
			floorTile2 = newTile;

		}
	}
}

