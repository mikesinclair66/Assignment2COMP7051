using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public bool isDaytime;
    public bool isFog;
    public bool isMusicOn;
    public AudioSource dayMusic;
    public AudioSource nightMusic;
    
    private float volume;
    private InputActions inputActions;
    private AudioSource currentMusic;

    public GameObject enemy;
    private float enemyDistance;

    public GameObject fogObj;

    private void Awake()
    {
        inputActions = new InputActions();
        
        inputActions.Player.ToggleMusic.performed += context =>
        {
            ToggleMusic();
        };
        
        inputActions.Player.ToggleFog.performed += context =>
        {
            ToggleFog();
        };
        
        inputActions.Player.ToggleDayNight.performed += context =>
        {
            ToggleDayNight();
        };
        currentMusic = dayMusic;
        isDaytime = true;
        isFog = false;
        volume = 1f;
    }

    private void Update()
    {
        enemyDistance = enemy.GetComponent<DudeEnemy>().Distance;
        currentMusic.volume = volume * ((2 / enemyDistance) + 0.2f);
        if (!currentMusic.isPlaying && isMusicOn)
        {
            currentMusic.Play();
        }

        if (!isMusicOn)
        {
            currentMusic.Stop();
        }
    }

    private void OnEnable()
    {
        inputActions.Player.ToggleMusic.Enable();
        inputActions.Player.ToggleFog.Enable();
        inputActions.Player.ToggleDayNight.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.ToggleMusic.Disable();
        inputActions.Player.ToggleFog.Disable();
        inputActions.Player.ToggleDayNight.Disable();
    }

    void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
    }

    void ToggleDayNight()
    {
        if (isDaytime)
        {
            isDaytime = false;
            currentMusic.Stop();
            currentMusic = nightMusic;
        }
        else
        {
            isDaytime = true;
            currentMusic.Stop();
            currentMusic = dayMusic;
        }
    }

    void ToggleFog()
    {
        if (isFog)
        {
            isFog = false;
            volume = 1f;
            fogObj.SetActive(false);
        }
        else
        {
            isFog = true;
            volume = 0.5f;
            fogObj.SetActive(true);
        }
    }
}
