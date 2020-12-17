using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public float offset = 5f;

	public Transform childObject;

	public Material[] wallMaterials;

	/// <summary>
	/// This is activated by a button
	/// 
	/// first, destroys child with old map
	/// goes through every pixel of a map sprite and generates tile assosiated with a color
	/// colors the walls of the labirynth
	/// </summary>
	public void GenerateLabirynth()
	{

		DestroyOldMap();

		for (int x = 0; x < map.width; x++)
		{
			for (int z = 0; z < map.height; z++)
			{
				GenerateTile(x, z);
			}
		}

		ColorTheWalls();
	}

	void GenerateTile(int x, int z)
	{
		//Pobieramy kolor pixela w pozycji x i y
		Color pixelColor = map.GetPixel(x, z);

		//Jeżeli alpha koloru jest równa 0, czyli kolor jest w pełni przezroczysty to pomijamy pixel
		if (pixelColor.a == 0)
		{
			return;
		}

		//Przeszukujemy po wszystkich kolorach w naszej tablicy
		foreach (ColorToPrefab colorMapping in colorMappings)
		{

			//Jeżeli któryś z kolorów w naszej tablicy odpowiada to ustaw prefab
			if (colorMapping.color.Equals(pixelColor))
			{

				//wylicz pozycje na podstawie współrzędnych pixela
				Vector3 position = new Vector3(x, 0, z) * offset;
				//Utwórz wybrany obiekt w wybranej pozycji
				var elem = Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
				elem.transform.parent = childObject.transform;
			}
		}
	}

	private void DestroyOldMap()
    {
		DestroyImmediate(transform.GetChild(0).gameObject);
		childObject = new GameObject("map").transform;
		childObject.transform.parent = gameObject.transform;
	}

	private void ColorTheWalls()
    {
		foreach (Transform child in childObject)
        {
            if (child.CompareTag("Wall"))
			{
				int random = Random.Range(1, 10);
				if(random <= 1)
                {
					child.gameObject.GetComponent<Renderer>().material = wallMaterials[1];
                }
				else if (random <= 3)
                {
					child.gameObject.GetComponent<Renderer>().material = wallMaterials[2];
				}
                else
                {
					child.gameObject.GetComponent<Renderer>().material = wallMaterials[0];
				}
            }
        }
    }

}
