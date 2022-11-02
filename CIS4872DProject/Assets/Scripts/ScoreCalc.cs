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
    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 1000f;
        scoreDeincrement = 1;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ((int)scoreAmount).ToString();
        scoreAmount -= scoreDeincrement * Time.deltaTime;
    }
}
