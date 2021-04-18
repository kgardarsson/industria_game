using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverScreen;

    private void OnTriggerEnter(Collider other)
    {
        GameOverScreen.SetActive(true);
        GameObject.Find("Player").GetComponent<Movement>().disableMovement();
    }
}
