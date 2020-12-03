using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diament : Pickup
{
    public int points;
    public override void Picked()
    {
        GameManager.gameManager.AddPoints(points);
        Destroy(this.gameObject);
    }
}
