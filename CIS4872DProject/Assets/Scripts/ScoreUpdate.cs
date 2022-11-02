using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float scoreAmount;
    public float scoreDeincrement;

    public TextMeshProUGUI loseText;

    public GameObject deathMenuUI;
    public GameObject ScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 6f;
        scoreDeincrement = 1;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Loot Left: " + ((int)scoreAmount).ToString();

        if (scoreAmount <= 0f)
        {
            Time.timeScale = 0f;
            ScoreUI.SetActive(false);
            deathMenuUI.SetActive(true);

            loseText.text = "Loot Lost!";
        }
        else
        {
            scoreAmount -= scoreDeincrement * Time.deltaTime;
        }
         
   
    }
}

