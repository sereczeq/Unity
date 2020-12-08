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
        if (Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked)
        {
            animator.SetBool("Open", CheckTheKey());
        }
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

    public void UseKey()
    {
        foreach (Door door in doors)
        {
            door.OpenClose();
        }
    }

    public bool CheckTheKey()
    {
        if (GameManager.gameManager.redKeys > 0 && color == KeyColor.Red)
        {
            GameManager.gameManager.redKeys--;
        }
        else if (GameManager.gameManager.greenKeys > 0 && color == KeyColor.Green)
        {
            GameManager.gameManager.greenKeys--;
        }
        else if (GameManager.gameManager.goldKeys > 0 && color == KeyColor.Gold)
        {
            GameManager.gameManager.goldKeys--;
        }
        else
        {
            Debug.Log("Nie masz klucza!");
            return false;
        }

        locked = true;
        return true;
    }


}
