using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple GameManagers in the Scene");
        }
    }

    //Gameplay
    public float worldScrollingSpeed = 0.1f;
    private float score = 0;

    //UI
    public Text scoreText;

    private void FixedUpdate()
    {
        score += worldScrollingSpeed;
        scoreText.text = score.ToString("0");
    }

    public void GameOver()
    {
        throw new NotImplementedException();
    }
}
