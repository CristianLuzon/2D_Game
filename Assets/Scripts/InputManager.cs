﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public CharacterBehaviour player;


	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBehaviour>();
	}
	

	void Update ()
    {
        // Leer para pausar el juego
        InputPause();
        // movimiento del player
        InputAxis();
        // salto del player
        InputJump();
        // alternar entre caminar y correr para el player
        InputRun();
	}

    void InputPause()
    {
        if(Input.GetButtonDown("Pause")) { Debug.Log("Pause"); }
    }
    void InputAxis()
    {
        Vector2 axis = Vector2.zero;
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");
        player.SetAxis(axis);
    }
    void InputJump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
            player.JumpStart();
        }
    }
    void InputRun()
    {
        if(Input.GetButtonDown("Run"))
        {
            Debug.Log("Run");
            player.isRunning = true;
        }
        if(Input.GetButtonUp("Run"))
        {
            player.isRunning = false;
            Debug.Log("Walk");
        }
    }

    void InputGodMode()
    {

    }
    void InputDirectAccess()
    {

    }
}
