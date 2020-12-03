using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public GameObject objectToFollow;

    private void LateUpdate()
    {
        transform.position = objectToFollow.transform.position;
    }

}
