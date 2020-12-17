using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public MusicScript musicScript;
    public int timeToEnd = 100;
    private KeyCode pauseButton = KeyCode.P;
    bool gamePaused = false;
    bool win = false;

    public int points = 0;
    public int redKeys = 0;
    public int goldKeys = 0;
    public int greenKeys = 0;

    //Audio
    public AudioSource audioSource;
    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip loseClip;
    public AudioClip pickedClip;

    bool timeRunningOut = false;
    private void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        InvokeRepeating("stopper", 0, 1);

        audioSource = GetComponent<AudioSource>();
        musicScript = GetComponentInChildren<MusicScript>();
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
        PlayClip(pauseClip);
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

        if (timeToEnd < 20 && !timeRunningOut)
        {
            LessTimeOn();
            timeRunningOut = true;
        } else if (timeToEnd > 20 && timeRunningOut)
        {
            LessTimeOff();
            timeRunningOut = false;
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

    public void PlayClip(AudioClip playClip)
    {
        audioSource.clip = playClip;
        audioSource.Play();
    }

    public void LessTimeOn()
    {
        musicScript.PitchThis(1.58f);
    }
    public void LessTimeOff()
    {
        musicScript.PitchThis(1f);
    }

}
