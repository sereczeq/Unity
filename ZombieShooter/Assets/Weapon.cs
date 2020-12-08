using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public int fireRate; // liczba pocisków na sekunde
    public int magazineSize; // wielkośc magazynka
    public int totalAmmo; // amunicja poza magazynkiem 

    public Transform gunEnd; // obiekt będący końcówka lufy, to  z niego będą wylatywać pociski
    public GameObject bullet; // prefab pocisku który będzie spawnowany
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, gunEnd.position, gunEnd.rotation);
        }
    }

}
