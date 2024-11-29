using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameUI : MonoBehaviour
{
    [SerializeField]  TMP_Text finalScoreText;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        finalScoreText.text = "You scored " + gameManager.finalScore + " out of 100";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
