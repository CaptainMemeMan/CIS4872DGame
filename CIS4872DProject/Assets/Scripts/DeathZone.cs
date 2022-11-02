using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject deathMenuUI;
    public GameObject ScoreUI;
    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreUI.SetActive(false);
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }
   
    
}
