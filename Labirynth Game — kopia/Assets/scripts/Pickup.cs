using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float rotationSpeed = 2.5f;

    public float levitateSpeed = 0.005f;
    public int levitateCount = 0;
    public int levitateCap = 30;
    
    private void Start()
    {
        gameObject.tag = "Pickup";
    }

    public virtual void Picked()
    {
        Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        Rotate();
        Levitate();
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }
    private void Levitate()
    {
        if (levitateCount < levitateCap)
        {
            transform.position = transform.position + new Vector3(0f, levitateSpeed, 0f);
        }
        else if (levitateCount < levitateCap * 2)
        {
            transform.position = transform.position + new Vector3(0f, -levitateSpeed, 0f);
        }
        else
        {
            levitateCount = -1;
        }
        levitateCount++;
    }

}
