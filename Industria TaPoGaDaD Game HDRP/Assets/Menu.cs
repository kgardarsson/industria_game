﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameObject player;
    Movement movement;
    GameObject cam;
    Footsteps footsteps;

    private void Awake()
    {
        player = GameObject.Find("Player");
        movement = player.GetComponent<Movement>();
        cam = player.gameObject.transform.GetChild(0).gameObject;
        footsteps = GameObject.Find("SFXController").GetComponent<Footsteps>();
    }

    public void Resume()
    {
        cam.GetComponent<CameraMovement>().enableMovement();
        cam.GetComponent<Interactor>().enableInteraction();
        movement.enableMovement();
        this.gameObject.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
