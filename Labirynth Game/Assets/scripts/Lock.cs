using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{

    public bool iCanOpen = false;

    public Door[] doors;
    public KeyColor color;
    bool locked = false;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            iCanOpen = true;
            Debug.Log("You are in keys distance");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            iCanOpen = false;
            Debug.Log("You are no longer in keys distance");
        }
    }
}
