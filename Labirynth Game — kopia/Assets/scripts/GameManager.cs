using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int timeToEnd = 100;
    private KeyCode pauseButton = KeyCode.P;
    bool gamePaused = false;
    bool win = false;

    public int points = 0;
    public int redKeys = 0;
    public int goldKeys = 0;
    public int greenKeys = 0;

    private void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        InvokeRepeating("stopper", 0, 1);
    }

    void Update()
    {
        if(Input.GetKeyDown(pauseButton))
        {
            if(gamePaused)
            {
                resumeGame();
            } else
            {
                pauseGame();
            }
        }
    }

    private void resumeGame()
    {
        Time.timeScale = 1f;
        gamePaused = false;
        Debug.Log("Game resumed!");
    }

    private void pauseGame()
    {
        Debug.Log("Game paused!");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    private void stopper()
    {
        // jeśli czas dobiegnie końca, napisz koniec czasu!
        if(timeToEnd <= 0)
        {
            endGame();
            return;
        }

        timeToEnd--;
        //Debug.Log("time to end is: " + timeToEnd);
    }

    public void endGame()
    {
        CancelInvoke("stopper");
        if(win)
        {
            Debug.Log("Congrats! You won the game");
        }
        else
        {
            Debug.Log("Booo, you lost :c");
        }
        pauseGame();
    }
    public void AddPoints(int point)
    {
        points += point;
    }

    public void AddKey(KeyColor color)
    {
        if(color == KeyColor.Red)           redKeys++; 
        else if (color == KeyColor.Gold)    goldKeys++;
        else if (color == KeyColor.Green)   greenKeys++;
    }

}
