using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{

    public Door[] doors;
    public KeyColor myColor;
    bool locked = false;
    Animator key;
    bool iCanOpen = false;


    void Start()
    {
        key = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked)
        {
            key.SetBool("useKey", CheckTheKey());
        }
    }

    public void UseKey()
    {
        foreach(Door door in doors)
        {
            door.OpenClose();
        }   
    }

    public bool CheckTheKey()
    {
        if(GameManager.gameManager.redKeys > 0 && myColor == KeyColor.Red)
        {
            GameManager.gameManager.redKeys--;
        }
        else if (GameManager.gameManager.greenKeys > 0 && myColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKeys--;
        }
        else if (GameManager.gameManager.goldKeys > 0 && myColor == KeyColor.Gold)
        {
            GameManager.gameManager.goldKeys--;
        } else
        {
            Debug.Log("You don't have the right key!");
            return false;
        }
            return locked = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            iCanOpen = true;
            Debug.Log("You Can Use Lock");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = false;
            Debug.Log("You Can not Use Lock");
        }
    }


}
