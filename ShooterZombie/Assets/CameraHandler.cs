using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform objectToFollow;

    //LateUpdate wykonuje po update
    private void LateUpdate()
    {
        transform.position = objectToFollow.position;
    }

}
