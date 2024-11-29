using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerButton : MonoBehaviour
{
    PlayerController player;
    public string enteredCode; 
    public string secretCode = "125"; 
    public int digit;
    public Powerbox powerBox;
    public bool powerIsOn = false;
    [SerializeField] AudioSource buttonPress;
    [SerializeField] AudioSource puzzleSolved;
    [SerializeField] AudioSource powerUpSound;
    [SerializeField] AudioSource incorrectCode;
    [SerializeField] Canvas thisCanvas;
    [SerializeField] Sprite onSprite;


    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    
    public void OnButtonPress(int digit)
    {
        enteredCode += digit.ToString();
        buttonPress.Play();
        Debug.Log(enteredCode);

        if (enteredCode.Length == 3)
        {
            if (enteredCode == secretCode)
            {
                Debug.Log("Correct code entered! Power is now on.");
                puzzleSolved.Play();
                powerUpSound.Play();
                powerIsOn = true;
                powerBox.isSolved = true;
                player.AddToScore(20);
                powerBox.spriteRenderer.sprite = onSprite;
                OnExitPress();
                player.DisplayText("Bingo! We have power.");
                
            }
            else
            {
                Debug.Log("Incorrect code.");
                incorrectCode.Play();
                enteredCode = ""; // Clear the input field for the next attempt
            }
        }
    }

    public void OnExitPress()
    {
        thisCanvas.enabled = false;
        powerBox.isActivated = false;
        powerBox.isClicked = false;
        enteredCode = "";
    }


}
