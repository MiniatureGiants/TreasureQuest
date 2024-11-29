using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using  UnityEngine.UI;

public class DesktopOpen : MonoBehaviour
{
    [SerializeField] Canvas desktopCanvas;
    [SerializeField] TMP_Text  pinCodeField;
    [SerializeField] TMP_Text  emailText;
    [SerializeField] GameObject desktopPanelBefore;
    [SerializeField] GameObject desktopPanelAfter;
    [SerializeField] AudioSource puzzleSolved;
    [SerializeField] AudioSource buttonPress;
    [SerializeField] AudioSource incorrectCode;
    BenWife painting;

    PlayerController player;

    public string desktopPin = "1933";
    public string enteredPin;
    
    void Start()
    {
        desktopPanelAfter.SetActive(false);
        emailText.enabled = false;
        pinCodeField.text = "";
        player = FindObjectOfType<PlayerController>();
        painting = FindObjectOfType<BenWife>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExitPress()
    {
        desktopCanvas.enabled = false;
        pinCodeField.text = "";
        enteredPin = "";
    }

    public void OnButtonPress(int digit)
    {
        enteredPin += digit.ToString();
        pinCodeField.text += "*";
        buttonPress.Play();
        Debug.Log(enteredPin);

        if (enteredPin.Length == 4)
        {
            if (enteredPin == desktopPin)
            {
                Debug.Log("Correct code entered! Power is now on.");
                desktopPanelBefore.SetActive(false);
                desktopPanelAfter.SetActive(true);
                emailText.enabled = true;
                puzzleSolved.Play();
                player.AddToScore(25);
                painting.hasReadEmail = true;
            }
            else
            {
                Debug.Log("Incorrect Pin.");
                incorrectCode.Play();
                enteredPin = ""; 
                pinCodeField.text = "";
            }
        }
    }

}
