using UnityEngine;

public class CoinAnimator : MonoBehaviour
{
    //Prędkość obrotu
    public float rotationSpeed = 5;
    // Update is called once per frame
    void FixedUpdate()
    {
        //Co tick fizyki obróć obiekt o rotationSpeed w osi y
        transform.Rotate(new Vector3(0f, rotationSpeed, 0f));
    }
}

